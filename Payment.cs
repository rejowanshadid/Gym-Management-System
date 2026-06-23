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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        

        private void btnBkash_Click(object sender, EventArgs e)
        {
            int userId = Session.ID;
            int PackageId = Session.PID;
            int amount = Session.Amount;

            int number = Convert.ToInt32(textBkash.Text);
            if (textBkash.Text == "")
            {
                MessageBox.Show("Enter Number ");
                return;
            }
            
            if (btnBkash.Enabled)
            {
                try
                {
                    MessageBox.Show("Thank you for your Response");

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.cs;
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = $"insert into Amount values ({userId},{PackageId},{amount},'Bkash','Pending')";
                    cmd.ExecuteNonQuery();
                    con.Close();



                    PackageDash ds = new PackageDash();
                    ds.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        


        private void button2_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(txtNagad.Text);
            if (txtNagad.Text == "")
            {
                MessageBox.Show("Enter Number ");
                return;
            }

            if (btnNagad.Enabled)
            {
                try
                {
                    MessageBox.Show("Purchase Successful by Nagad");
                   
                    PackageDash ds = new PackageDash();
                    ds.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(txtCard.Text);
            if (txtCard.Text == "")
            {
                MessageBox.Show("Enter Number ");
                return;
            }

            if (txtCard.Enabled)
            {
                try
                {
                    MessageBox.Show("Purchase Successful by Nagad");
                    
                    PackageDash ds = new PackageDash();
                    ds.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
    }
}
