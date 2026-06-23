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

namespace project
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            if (name == "")
            {
               
                MessageBox.Show("Please Fill Your Name");
                txtName.Focus();
                txtName.BackColor = Color.DarkGray;
                txtName.ForeColor = Color.Black;

                return;
            }else {
                 txtName.BackColor= Color.White;
            }

             string email = "";
            email = textEmail.Text;
            if (email == "")
            {
                MessageBox.Show("Please Fill Email.");
                textEmail.BackColor= Color.DarkGray;
                return;

            }
           
            if (email.Contains('@')==false)
            {
                MessageBox.Show("Uffs You May forgot to add '@' or '.' ");
                return;
            }
            else
            {
                textEmail.BackColor = Color.White;
            }

            int phone=0;
           
            if(txtPhone.Text == "")
            {
                MessageBox.Show("Phone number required");
                return;
            }
            if (txtPhone.TextLength!=11)
            {
                MessageBox.Show("11 numeric number required");
                return;
            }
            try
            {
                phone = Convert.ToInt32(txtPhone.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Numeric number required");
                return;
            }
          
           
            

            string password = txtPass.Text;
           
            if (password=="" )
            {
               
                txtPass.BackColor = Color.DarkGray;
                txtPass.ForeColor = Color.Blue;
                MessageBox.Show("Password required");
                txtPass.Focus();
                
                return;
            }
            else if (password.Length<=5) {
                MessageBox.Show("More than 5 char required.");
                return;
            }
           


            string gender = "";
            if (radioButton1.Checked)
            {
                gender = "Male";


            }
            else if (radioButton2.Checked) {
                gender = "Female";
            }else
            {
                MessageBox.Show("Please select Gender");
                return;
            }

           
            
                try
                {
                    SqlConnection con = new SqlConnection(); // Connection dewa
                    con.ConnectionString = ApplicationHelper.cs;

                    con.Open();

                    SqlCommand cmd = new SqlCommand(); // panel banano
                    cmd.Connection = con; // database select hoye gese
                    cmd.CommandText = $"insert into UserInfo values ('{name}','{email}','{phone}','{password}','{gender}','Customer')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                 


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


              MessageBox.Show("Dear " + name + " Your Registration is Successful.");

              HomePage hp = new HomePage();
              hp.Show();
              this.Hide();
           





        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar=true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

       

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(51,51,76);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
