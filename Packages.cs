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
    public partial class Packages : Form
    {
        public Packages()
        {
            InitializeComponent();
        }

        private void btnPack_MouseHover(object sender, EventArgs e)
        {
            btnPack.BackColor = Color.FromArgb(74, 108, 230);
        }

        private void btnPack_MouseLeave(object sender, EventArgs e)
        {
            btnPack.BackColor = Color.FromArgb(92, 124, 250);
        }

        private void btnHLogin_MouseHover(object sender, EventArgs e)
        {
            btnHLogin.BackColor = Color.FromArgb(74, 108, 230);
        }

        private void btnHLogin_MouseLeave(object sender, EventArgs e)
        {
            btnHLogin.BackColor = Color.FromArgb(74, 108, 230);
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            this.Hide();
            hp.Show();
        }

        private void Packages_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomePage hp = new HomePage();
            this.Hide();
            hp.Show();
        }

        private void Packages_Load(object sender, EventArgs e)
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
                Height = 220,
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
                BackColor = Color.FromArgb(204, 232, 255),
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

            panel.Controls.Add(lblName);
            panel.Controls.Add(lblDetails);
            panel.Controls.Add(lblDuration);
            panel.Controls.Add(lblPrice);

            return panel;
        }

    }
}
