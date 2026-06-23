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
using System.Xml.Linq;
using GreyGym;

namespace GreyGym
{
    public partial class ManegerialView_Amount_ : Form
    {
        public ManegerialView_Amount_()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select Amount.* , UserInfo.Name as 'User Name',Package.PackageName as 'Package Name' from Amount inner join UserInfo on UserInfo.ID = Amount.UserId inner join Package on Package.ID = Amount.PackageId ;select * from UserInfo ;select * from Package";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();

                DataTable dt1 = ds.Tables[1];
                cmbUser.DataSource = dt1;
                cmbUser.ValueMember = "ID";
                cmbUser.DisplayMember = "Name";
                

                DataTable dt2 = ds.Tables[2];
                cmbPackage.DataSource = dt2;
                cmbPackage.ValueMember = "ID";
                cmbPackage.DisplayMember = "PackageName";
                con.Close();
                
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ManegerialView_Amount__Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbUser.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbPackage.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbMethod.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbPaymetStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                
              
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshAll();
        }

        private void RefreshAll()
        {
            txtId.Text = "Auto Generated";
            cmbMethod.Text = "";
            cmbPackage.Text = "";
            cmbPaymetStatus.Text = "";
            cmbUser.Text = "";
            txtAmount.Text = "";

            dataGridView1.ClearSelection();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string userId = cmbUser.SelectedValue.ToString();
            string packageId = cmbPackage.SelectedValue.ToString();
            int amount = Convert.ToInt32(txtAmount.Text);
            string method = cmbMethod.Text;
            string status = cmbPaymetStatus.Text;

            if (id == "Auto Generated")
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                //Get OLD payment status
                string oldStatus = "";

                SqlCommand cmdOld = new SqlCommand();
                cmdOld.Connection = con;
                cmdOld.CommandText =
                    $"select PaymentStatus from Amount where ID = {id}";

                DataSet dsOld = new DataSet();
                SqlDataAdapter adpOld = new SqlDataAdapter(cmdOld);
                adpOld.Fill(dsOld);

                if (dsOld.Tables[0].Rows.Count > 0)
                {
                    oldStatus = dsOld.Tables[0].Rows[0]["PaymentStatus"].ToString();
                }

                //Update Amount table
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    $"update Amount set UserId={userId}, PackageId={packageId}, Amount={amount}, " +
                    $"Method='{method}', PaymentStatus='{status}' where ID={id}";
                cmd.ExecuteNonQuery();

                if (oldStatus != "Confirmed" && status == "Confirmed")
                {
                    //Checking active subscription
                    SqlCommand cmdCheck = new SqlCommand();
                    cmdCheck.Connection = con;
                    cmdCheck.CommandText =
                        $"select * from UserPackage where UserId = {userId} and IsActive = 'Yes'";

                    DataSet dsCheck = new DataSet();
                    SqlDataAdapter adpCheck = new SqlDataAdapter(cmdCheck);
                    adpCheck.Fill(dsCheck);

                    DataTable dtCheck = dsCheck.Tables[0];

                    SqlCommand cmdPackage = new SqlCommand();
                    cmdPackage.Connection = con;
                    cmdPackage.CommandText = $"select Duration from Package where ID = {packageId}";
                    DataSet dsPackage = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(cmdPackage);
                    adp.Fill(dsPackage);


                    int durationMonths = 1;
                    if (dsPackage.Tables[0].Rows.Count > 0)
                        durationMonths = Convert.ToInt32(dsPackage.Tables[0].Rows[0]["Duration"]);

                    DateTime startDate = DateTime.Now;
                    DateTime endDate = startDate.AddMonths(durationMonths);


                    //NEW subscription
                    if (dtCheck.Rows.Count == 0)
                    {
                        SqlCommand cmdPack = new SqlCommand();
                        cmdPack.Connection = con;
                        cmdPack.CommandText =
                            $"insert into UserPackage (UserId, PackId, StartDate, EndDate, IsActive) " +
                            $"values ({userId}, {packageId}, '{startDate}', '{endDate}', 'Yes')";
                        cmdPack.ExecuteNonQuery();

                        SqlCommand cmdDiet = new SqlCommand();
                        cmdDiet.Connection = con;
                        cmdDiet.CommandText =
                            $"insert into DietPlan (UserID,StartDate) " +
                            $"values ({userId}, '{startDate}')" +
                            $"select ID from DietPlan where UserID = '{userId}'"; 


                        DataSet dsDiet = new DataSet();
                        SqlDataAdapter adpD = new SqlDataAdapter(cmdDiet);
                        adpD.Fill(dsDiet);

                        int dietId = Convert.ToInt32(dsDiet.Tables[0].Rows[0]["ID"]);

                        SqlCommand cmdTrainer = new SqlCommand();
                        cmdTrainer.Connection = con;
                        cmdTrainer.CommandText =
                            $"insert into TrainerUser (CustomerID, PackID, DietID, AssignDate) " +
                            $"values ({userId}, {packageId}, {dietId}, '{startDate}')";
                        cmdTrainer.ExecuteNonQuery();

                    }
                    else
                    {
                        DateTime currentEndDate = Convert.ToDateTime(dtCheck.Rows[0]["EndDate"]);
                        DateTime newEndDate = currentEndDate.AddMonths(durationMonths);
                        string newEndDateStr = newEndDate.ToString("yyyy-MM-dd HH:mm:ss");

                        SqlCommand cmdRenew = new SqlCommand();
                        cmdRenew.Connection = con;
                        cmdRenew.CommandText =
                            $"update UserPackage set EndDate = '{newEndDateStr}' " +
                            $"where UserId = {userId} and IsActive = 'Yes'";
                        cmdRenew.ExecuteNonQuery();

                        //update package if upgraded
                        SqlCommand cmdUpdatePack = new SqlCommand();
                        cmdUpdatePack.Connection = con;
                        cmdUpdatePack.CommandText =
                            $"update UserPackage set PackId = {packageId} " +
                            $"where UserId = {userId} and IsActive = 'Yes'";
                        cmdUpdatePack.ExecuteNonQuery();

                        SqlCommand cmdTrainerUpdate = new SqlCommand();
                        cmdTrainerUpdate.Connection = con;
                        cmdTrainerUpdate.CommandText =
                            $"update TrainerUser set PackID = {packageId} " +
                            $"where CustomerID = {userId}";
                        cmdTrainerUpdate.ExecuteNonQuery();
                    }
                }

                con.Close();
                MessageBox.Show("Updated Successfully");
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
