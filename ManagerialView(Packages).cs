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
using project;

namespace GreyGym
{
    public partial class ManagerialView_Packages_ : Form
    {
        public ManagerialView_Packages_()
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
                cmd.CommandText = "select * from Package";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();



            }
            catch(Exception ex)
            {

            }
        }

        private void ManagerialView_Packages__Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPackage.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ttxDuration.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                rDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RefreshAll()
        {
            txtId.Text = "Auto Generated";
            txtPackage.Text = "";
            ttxDuration.Text = "";
            txtPrice.Text = "";
            rDesc.Text = "";

            dataGridView1.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void AddData()
        {
            string pack = txtPackage.Text;
            int duration = Convert.ToInt32( ttxDuration.Text);
            int price = Convert.ToInt32(txtPrice.Text);
            string desc = rDesc.Text;


            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Package values ('{pack}',{duration},{price},'{desc}')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Package Added Successfully");

                this.LoadData();
               



            }
            catch (Exception ex)
            {

            }
        }

        private void Update()
        {
            int id = Convert.ToInt32(txtId.Text);
            string Pack = txtPackage.Text;
            int duration = Convert.ToInt32( ttxDuration.Text);
            int price = Convert.ToInt32 (txtPrice.Text);
            string desc = rDesc.Text;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"Update  Package set PackageName = '{Pack}',Duration = {duration} , Price = {price} , Description = '{desc}' where id = {id}";
                
                MessageBox.Show("Updated Successfully");
                cmd.ExecuteNonQuery();
                this.LoadData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "Auto Generated")
            {
                this.AddData();
            }
            else
            {
                this.Update();
            }

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ManagerialView_User_ u = new ManagerialView_User_();
            u.Show();
            this.Hide();
        }

        private void btnPaymet_Click(object sender, EventArgs e)
        {
            ManegerialView_Amount_ a = new ManegerialView_Amount_();
            a.Show();
            this.Hide();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
