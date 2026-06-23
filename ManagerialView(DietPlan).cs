using GreyGym;
using Microsoft.SqlServer.Server;
using project;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GreyGym
{
    public partial class ManagerialView_DietPlan_ : Form
    {
        public ManagerialView_DietPlan_()
        {
            InitializeComponent();
        }

        private void ManagerialView_User__Load(object sender, EventArgs e)
        {
            this.LoadData();
            
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

                cmd.CommandText =
                                    $"SELECT dp.ID, dp.UserID, ui.Name AS CustomerName, " +
                                    $"dp.TrainerID, ti.Name AS TrainerName, " +
                                    $"dp.CurrentWeight, dp.TargetWeight, dp.Goal, " +
                                    $"dp.FoodPlan, dp.StartDate " +
                                    $"FROM DietPlan dp " +
                                    $"INNER JOIN UserInfo ui ON ui.ID = dp.UserID " +
                                    $"INNER JOIN UserInfo ti ON ti.ID = dp.TrainerID";


                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RefreshAll()
        {
            txtId.Text = "Auto Generated";
            txtName.Text = "";
            txtTrainerName.Text = "";
            txtCurrWt.Text = "";
            txtTarWt.Text = "";
            cmbGoal.Text = "";
            rtxtFoodPlan.Text = "";
            dtpStart.Text = "";
      
            dataGridView1.ClearSelection();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTrainerName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCurrWt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtTarWt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cmbGoal.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                rtxtFoodPlan.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                dtpStart.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            }

        }


        private void btnPaymet_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerialView_Amount_ mga = new ManegerialView_Amount_();
            mga.Show();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string customerName = txtName.Text;
            string trainerName = txtTrainerName.Text;
            string currWt = txtCurrWt.Text;
            string tarWt = txtTarWt.Text;
            string goal = cmbGoal.Text;
            string diet = rtxtFoodPlan.Text;

            DateTime startDate = dtpStart.Value;
            string startDateStr = startDate.ToString("yyyy-MM-dd");

            if (id == "Auto Generated")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.cs;
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = $"insert into DietPlan " +
                                      $"(UserID, TrainerID, CurrentWeight, TargetWeight, Goal, FoodPlan, StartDate) " +
                                      $"values ( " +
                                      $"(select ID from UserInfo where Name = '{customerName}'), " +
                                      $"(select ID from UserInfo where Name = '{trainerName}'), " +
                                      $"{currWt}, {tarWt}, '{goal}', '{diet}', '{startDateStr}' )";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                    this.LoadData();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {

                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.cs;
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = $"update DietPlan set " +
                                      $"CurrentWeight = {currWt}, " +
                                      $"TargetWeight = {tarWt}, " +
                                      $"Goal = '{goal}', " +
                                      $"FoodPlan = '{diet}', " +
                                      $"StartDate = '{startDateStr}' " +
                                      $"where ID = {id}";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated Successfully");
                    this.LoadData();
                    this.RefreshAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
