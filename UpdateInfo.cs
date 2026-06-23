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
    public partial class UpdateInfo : Form
    {
        public UpdateInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void RefreshAll()
        {
            txtName.Text = "";
            txtPass.Text = "";
            txtPhone.Text = "";
            txtGmail.Text = "";
            cmbGender.Text = "";

            dataGridView1.ClearSelection();
        }

        private void LoadData()
        {
            int id = Session.ID;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"select Name,Gmail,Phone,Password,Gender from UserInfo where ID ={id}";

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

        private void UpdateInfo_Load(object sender, EventArgs e)
        {
            label2.Text = Session.Name;

            int id = Session.ID;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select Name,Gmail,Phone,Password,Gender from UserInfo where ID = {id}";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPass.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGmail.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Session.ID;
            string name = txtName.Text;
            string pass = txtPass.Text;
            int phone = Convert.ToInt32(txtPhone.Text);
            string gmail = txtGmail.Text;
            string gender = cmbGender.Text;



            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"update UserInfo set Name = '{name}',Gmail='{gmail}',Phone ='{phone}',Password='{pass}',Gender = '{gender}' where ID ={id}";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfull");
                this.LoadData();
                this.RefreshAll();

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerHome C = new CustomerHome();
            C.Show();
            this.Hide();
        }
    }
}
