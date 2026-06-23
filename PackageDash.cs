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
    public partial class PackageDash : Form
    {
        public PackageDash()
        {
            InitializeComponent();
        }

        private void PackageDash_Load(object sender, EventArgs e)
        {
            this.LoadPanels();
        }

        private void LoadPanels()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Package";

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();

                var dt = ds.Tables[0];
                int top = 10;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["ID"].ToString();
                    string name = dt.Rows[i]["PackageName"].ToString();
                    string desc = dt.Rows[i]["Description"].ToString();
                    string duration = dt.Rows[i]["Duration"].ToString();
                    string price = dt.Rows[i]["Price"].ToString();
                    Panel panel = CreatePackagePanel(id, name, desc, duration, price);
                    panel.Top = top;
                    panel.Left = 10;

                    this.fpPackageDash.Controls.Add(panel);

                    top += panel.Height + 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Panel CreatePackagePanel(string id, string name, string desc, string duration, string price)
        {
            Panel panel = new Panel
            {
                Width = 250,
                Height = 250,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblName = new Label
            {
                Text = "[" + name + "]",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Left = 0,
                Top = 0,
                Width = panel.Width,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(0, 191, 255),
                ForeColor = Color.Black
            };

            Label lblDetails = new Label
            {
                Text = desc,
                Left = 10,
                Top = 40,
                Width = panel.Width - 20,
                Height = 80,
                AutoSize = false
            };

            Label lblDuration = new Label
            {
                Text = "Duration : " + duration + " Months",
                Left = 10,
                Top = 130,
                Width = panel.Width - 20,
                AutoSize = false,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };


            Label lblPrice = new Label
            {
                Text = "Price: BDT " + price,
                Left = 10,
                Top = 165,
                Width = panel.Width - 20,
                AutoSize = false,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };

            Button btnBuy = new Button
            {
                Text = "Buy Now",
                Width = 100,
                Height = 30,
                Left = (panel.Width - 100) / 2,
                Top = 200,
                Tag = id
            };

            btnBuy.Click += BuyButton_Click;

            panel.Controls.Add(lblName);
            panel.Controls.Add(lblDetails);
            panel.Controls.Add(lblDuration);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(btnBuy);

            return panel;
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int packageId = Convert.ToInt32(btn.Tag.ToString());

            var sure = MessageBox.Show("Are you sure you want to buy this package?", "Confirmation", MessageBoxButtons.YesNo);



            if (sure == DialogResult.Yes)
            {
                try
                {
                    var connection = new SqlConnection();
                    connection.ConnectionString = ApplicationHelper.cs;
                    connection.Open();

                    var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"select * from Package where ID = {packageId} ";

                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    connection.Close();



                    int Pack = Convert.ToInt32(dt.Rows[0]["ID"]);
                    Session.PID = Pack;
                    int amount = Convert.ToInt32(dt.Rows[0]["Price"]);
                    Session.Amount = amount;

                    Payment pm = new Payment();
                    pm.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (sure == DialogResult.No)
            {

                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerHome C = new CustomerHome();
            C.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInfo U = new UpdateInfo();
            U.Show();
            this.Hide();
        }
    }
}
