using GreyGym;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class CustomerHome : Form
    {
        public CustomerHome()
        {
            InitializeComponent();
        }

        private void CustomerHome_Load(object sender, EventArgs e)
        {
            labWelcome.Text = Session.Name;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                DateTime now = DateTime.Now;
                string nowStr = now.ToString("yyyy-MM-dd HH:mm:ss");

                // Expire old packages
                SqlCommand cmdExpire = new SqlCommand();
                cmdExpire.Connection = con;
                cmdExpire.CommandText =
                    $"update UserPackage set IsActive = 'No' " +
                    $"where EndDate < '{nowStr}' and IsActive = 'Yes'";
                cmdExpire.ExecuteNonQuery();

                // Check active package
                SqlCommand cmdCheck = new SqlCommand();
                cmdCheck.Connection = con;
                cmdCheck.CommandText =
                    $"SELECT PackId, IsActive, EndDate " +
                    $"FROM UserPackage " +
                    $"WHERE UserId = {Session.ID} AND IsActive = 'Yes'";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmdCheck);
                adp.Fill(ds);


                if (ds.Tables[0].Rows.Count == 0)
                {
                    labPack.Text = "No active package";
                    labTrainer.Text = "Not Assigned";
                    labGoal.Text = "No goal set";
                    rtxtDiet.Text = "Diet plan not assigned yet.";

                    con.Close();
                    return;
                }


                int packId = Convert.ToInt32(ds.Tables[0].Rows[0]["PackId"]);
                string isActive = ds.Tables[0].Rows[0]["IsActive"].ToString();
                DateTime endDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]);

                if (isActive == "No")
                {
                    labPack.Text = "No active package";
                    labTrainer.Text = "Not Assigned";
                    labGoal.Text = "No goal set";
                    rtxtDiet.Text = "Diet plan not assigned yet.";

                    MessageBox.Show(
                        "Your subscription has expired.\nPlease renew to continue.",
                        "Subscription Expired",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    con.Close();
                    return;
                }

                // Package name fetch
                SqlCommand cmdPackage = new SqlCommand();
                cmdPackage.Connection = con;
                cmdPackage.CommandText =
                    $"select PackageName from Package where ID = {packId}";

                DataSet dsPackage = new DataSet();
                SqlDataAdapter adp1 = new SqlDataAdapter(cmdPackage);
                adp1.Fill(dsPackage);

                if (dsPackage.Tables[0].Rows.Count > 0)
                    labPack.Text = dsPackage.Tables[0].Rows[0]["PackageName"].ToString();
                else
                    labPack.Text = "Unknown";

                // Trainer name fetch
                SqlCommand cmdTrainer = new SqlCommand();
                cmdTrainer.Connection = con;
                cmdTrainer.CommandText =
                    "SELECT u.Name " +
                    "FROM TrainerUser tu " +
                    "JOIN UserInfo u ON tu.TrainerID = u.ID " +
                    $"WHERE tu.CustomerID = {Session.ID} AND tu.PackID = {packId}";

                DataSet dsTrainer = new DataSet();
                new SqlDataAdapter(cmdTrainer).Fill(dsTrainer);

                if (dsTrainer.Tables[0].Rows.Count > 0)
                    labTrainer.Text = dsTrainer.Tables[0].Rows[0]["Name"].ToString();
                else
                    labTrainer.Text = "Not Assigned";

                // Goal fetch
                SqlCommand cmdGoal = new SqlCommand();
                cmdGoal.Connection = con;
                cmdGoal.CommandText =
                    $"select Goal from DietPlan where UserID = {Session.ID}";

                DataSet dsGoal = new DataSet();
                new SqlDataAdapter(cmdGoal).Fill(dsGoal);

                if (dsGoal.Tables[0].Rows.Count > 0)
                    labGoal.Text = dsGoal.Tables[0].Rows[0]["Goal"].ToString();
                else
                    labGoal.Text = "No goal set";

                // Diet plan fetch
                SqlCommand cmdDiet = new SqlCommand();
                cmdDiet.Connection = con;
                cmdDiet.CommandText =
                    $"select FoodPlan from DietPlan where UserID = {Session.ID}";

                DataSet dsDiet = new DataSet();
                new SqlDataAdapter(cmdDiet).Fill(dsDiet);

                if (dsDiet.Tables[0].Rows.Count > 0)
                    rtxtDiet.Text = dsDiet.Tables[0].Rows[0]["FoodPlan"].ToString();
                else
                    rtxtDiet.Text = "Diet plan not assigned yet.";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            PackageDash pd = new PackageDash();
            pd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInfo U = new UpdateInfo();
            U.Show();
            this.Hide();
        }
    }
}
