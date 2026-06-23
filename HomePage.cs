using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyGym
{
    public partial class HomePage : Form
    {
        public HomePage()
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

        private void btnHLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            Packages pg = new Packages();
            pg.Show();
            this.Hide();
        }
    }
}
