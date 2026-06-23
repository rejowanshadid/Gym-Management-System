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

namespace GreyGym
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Enter Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtPass_Enter_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "Enter Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave_1(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.Text = "Enter Password";
                txtPass.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(51, 51, 120);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void linlabRegi_MouseHover(object sender, EventArgs e)
        {
            linlabRegi.LinkColor = Color.FromArgb(51, 51, 120);
        }

        private void linlabRegi_MouseLeave(object sender, EventArgs e)
        {
            linlabRegi.LinkColor = Color.FromArgb(51, 51, 76);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void linlabRegi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registration rg = new Registration();
            rg.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Gmail = txtEmail.Text;
            string Password = txtPass.Text;

            try
            {
                var connection = new SqlConnection();
                connection.ConnectionString = ApplicationHelper.cs;
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $"select * from UserInfo where Gmail = '{Gmail}' and Password = '{Password}'";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                connection.Close();

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid Email or Password");
                    return;
                }
  
                    int userId = Convert.ToInt32(dt.Rows[0]["ID"]);
                    Session.ID = userId;
                    Session.Name = dt.Rows[0]["Name"].ToString();
                    string type = dt.Rows[0]["Usertype"].ToString();

                if(type == "Customer")
                {
                    CustomerHome ch = new CustomerHome();
                    this.Hide();
                    ch.Show();
                }

                else if(type == "Admin")
                {
                    ManagerialView_User_ mgu = new ManagerialView_User_();
                    this.Hide();
                    mgu.Show();
                }
                
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
