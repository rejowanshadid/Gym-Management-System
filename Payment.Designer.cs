namespace project
{
    partial class Payment
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
            this.btnCard = new System.Windows.Forms.Button();
            this.btnNagad = new System.Windows.Forms.Button();
            this.btnBkash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBkash = new System.Windows.Forms.TextBox();
            this.txtNagad = new System.Windows.Forms.TextBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCard
            // 
            this.btnCard.BackgroundImage = global::GreyGym.Properties.Resources.OIP;
            this.btnCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.Location = new System.Drawing.Point(316, 306);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(118, 75);
            this.btnCard.TabIndex = 2;
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnNagad
            // 
            this.btnNagad.BackgroundImage = global::GreyGym.Properties.Resources._71de1a123637063_Y3JvcCwxMzgyLDEwODEsMzA0LDA;
            this.btnNagad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNagad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNagad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNagad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNagad.Location = new System.Drawing.Point(316, 183);
            this.btnNagad.Name = "btnNagad";
            this.btnNagad.Size = new System.Drawing.Size(129, 77);
            this.btnNagad.TabIndex = 1;
            this.btnNagad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNagad.UseVisualStyleBackColor = true;
            this.btnNagad.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBkash
            // 
            this.btnBkash.BackgroundImage = global::GreyGym.Properties.Resources.BKash_Group_of_Logos_08;
            this.btnBkash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBkash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBkash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBkash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBkash.Location = new System.Drawing.Point(316, 70);
            this.btnBkash.Name = "btnBkash";
            this.btnBkash.Size = new System.Drawing.Size(129, 81);
            this.btnBkash.TabIndex = 0;
            this.btnBkash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBkash.UseVisualStyleBackColor = true;
            this.btnBkash.Click += new System.EventHandler(this.btnBkash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Choose a Payment Method";
            // 
            // textBkash
            // 
            this.textBkash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBkash.Location = new System.Drawing.Point(26, 92);
            this.textBkash.Name = "textBkash";
            this.textBkash.Size = new System.Drawing.Size(224, 38);
            this.textBkash.TabIndex = 4;
            // 
            // txtNagad
            // 
            this.txtNagad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNagad.Location = new System.Drawing.Point(26, 203);
            this.txtNagad.Name = "txtNagad";
            this.txtNagad.Size = new System.Drawing.Size(224, 38);
            this.txtNagad.TabIndex = 5;
            // 
            // txtCard
            // 
            this.txtCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCard.Location = new System.Drawing.Point(26, 325);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(224, 38);
            this.txtCard.TabIndex = 6;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(474, 450);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.txtNagad);
            this.Controls.Add(this.textBkash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnNagad);
            this.Controls.Add(this.btnBkash);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBkash;
        private System.Windows.Forms.Button btnNagad;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBkash;
        private System.Windows.Forms.TextBox txtNagad;
        private System.Windows.Forms.TextBox txtCard;
    }
}