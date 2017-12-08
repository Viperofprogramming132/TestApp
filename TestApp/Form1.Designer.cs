namespace TestApp
{
    partial class Form1
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
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.cmbCabinet = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblCabinet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(97, 12);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(121, 21);
            this.cmbCountry.TabIndex = 0;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(97, 39);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 21);
            this.cmbSite.TabIndex = 1;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            this.cmbSite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbSite_MouseClick);
            // 
            // cmbCabinet
            // 
            this.cmbCabinet.FormattingEnabled = true;
            this.cmbCabinet.Location = new System.Drawing.Point(96, 66);
            this.cmbCabinet.Name = "cmbCabinet";
            this.cmbCabinet.Size = new System.Drawing.Size(121, 21);
            this.cmbCabinet.TabIndex = 2;
            this.cmbCabinet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbCabinet_MouseClick);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(12, 15);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "Country";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(12, 42);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(25, 13);
            this.lblSite.TabIndex = 4;
            this.lblSite.Text = "Site";
            // 
            // lblCabinet
            // 
            this.lblCabinet.AutoSize = true;
            this.lblCabinet.Location = new System.Drawing.Point(12, 69);
            this.lblCabinet.Name = "lblCabinet";
            this.lblCabinet.Size = new System.Drawing.Size(43, 13);
            this.lblCabinet.TabIndex = 5;
            this.lblCabinet.Text = "Cabinet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.lblCabinet);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cmbCabinet);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.cmbCountry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.ComboBox cmbCabinet;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblCabinet;
    }
}

