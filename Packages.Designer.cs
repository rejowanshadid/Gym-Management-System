namespace GreyGym
{
    partial class Packages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Packages));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHLogin = new System.Windows.Forms.Button();
            this.btnPack = new System.Windows.Forms.Button();
            this.fpPackageDash = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.fpPackageDash);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(34, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 575);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(407, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "GreyGym Offered Packages";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pictureBox1.BackgroundImage = global::GreyGym.Properties.Resources.image_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(310, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnHLogin);
            this.panel2.Controls.Add(this.btnPack);
            this.panel2.Location = new System.Drawing.Point(34, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 34);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JetBrainsMono NF", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "GreyGym";
            // 
            // btnHLogin
            // 
            this.btnHLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.btnHLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHLogin.ForeColor = System.Drawing.Color.White;
            this.btnHLogin.Location = new System.Drawing.Point(881, 3);
            this.btnHLogin.Name = "btnHLogin";
            this.btnHLogin.Size = new System.Drawing.Size(123, 28);
            this.btnHLogin.TabIndex = 1;
            this.btnHLogin.Text = "Login";
            this.btnHLogin.UseVisualStyleBackColor = false;
            this.btnHLogin.MouseLeave += new System.EventHandler(this.btnHLogin_MouseLeave);
            this.btnHLogin.MouseHover += new System.EventHandler(this.btnHLogin_MouseHover);
            // 
            // btnPack
            // 
            this.btnPack.BackColor = System.Drawing.Color.White;
            this.btnPack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPack.ForeColor = System.Drawing.Color.Black;
            this.btnPack.Location = new System.Drawing.Point(744, 3);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(120, 28);
            this.btnPack.TabIndex = 0;
            this.btnPack.Text = "Home";
            this.btnPack.UseVisualStyleBackColor = false;
            this.btnPack.Click += new System.EventHandler(this.btnPack_Click);
            this.btnPack.MouseLeave += new System.EventHandler(this.btnPack_MouseLeave);
            this.btnPack.MouseHover += new System.EventHandler(this.btnPack_MouseHover);
            // 
            // fpPackageDash
            // 
            this.fpPackageDash.AutoScroll = true;
            this.fpPackageDash.Location = new System.Drawing.Point(8, 89);
            this.fpPackageDash.Name = "fpPackageDash";
            this.fpPackageDash.Size = new System.Drawing.Size(1004, 485);
            this.fpPackageDash.TabIndex = 8;
            // 
            // Packages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GreyGym.Properties.Resources.health_club_without_people_with_exercise_equipment;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1107, 644);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Packages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GreyGym";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Packages_FormClosing);
            this.Load += new System.EventHandler(this.Packages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHLogin;
        private System.Windows.Forms.Button btnPack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel fpPackageDash;
    }
}