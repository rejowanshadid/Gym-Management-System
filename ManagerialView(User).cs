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
using GreyGym;
using Microsoft.SqlServer.Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GreyGym
{
    public partial class ManagerialView_User_ : Form
    {
        public ManagerialView_User_()
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

                cmd.CommandText = "select * from UserInfo";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void RefreshAll()
        {
            txtId.Text = "Auto Generated";
            txtName.Text = "";
            txtGmail.Text = "";
            txtPhone.Text = "";
            txtPass.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
      
            dataGridView1.ClearSelection();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtGmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPass.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbUserType.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id  = txtId.Text;
            if(id=="Auto Generated")
            {
                MessageBox.Show("Please Select a row first.");
                return;
            }

          var result =  MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo);
            if(result == DialogResult.No)
            {
                return;
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

                    cmd.CommandText = $"delete from UserInfo where ID = {id}";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Deleted Successfully");
                    this.LoadData();
                    this.RefreshAll();
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string name = txtName.Text;
            string gmail = txtGmail.Text;
            int phone = Convert.ToInt32( txtPhone.Text);
            string pass = txtPass.Text;
            string gender = cmbGender.Text;
            string UserType = cmbUserType.Text;

            if(id=="Auto Generated")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.cs;
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = $"insert into UserInfo values ('{name}','{gmail}','{phone}','{pass}','{gender}','Customer')";
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

                    cmd.CommandText = $"update UserInfo set Name = '{name}',Gmail='{gmail}',Password='{pass}',Phone ='{phone}',Gender = '{gender}',UserType='{UserType}' where id ={id}";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPaymet_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManegerialView_Amount_ mga = new ManegerialView_Amount_();
            mga.Show();

        }
    }
}
