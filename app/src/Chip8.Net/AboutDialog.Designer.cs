namespace Chip8.Net
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lkSite = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(84, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(126, 20);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Chip8.Net";
            // 
            // lbDescription
            // 
            this.lbDescription.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(12, 42);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(260, 42);
            this.lbDescription.TabIndex = 1;
            this.lbDescription.Text = "Chip-8 implemented in c# \r\n\r\nAuthor: Alexandre Barbieri (fakeezz)";
            // 
            // lkSite
            // 
            this.lkSite.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lkSite.AutoSize = true;
            this.lkSite.Location = new System.Drawing.Point(85, 84);
            this.lkSite.Name = "lkSite";
            this.lkSite.Size = new System.Drawing.Size(106, 13);
            this.lkSite.TabIndex = 2;
            this.lkSite.TabStop = true;
            this.lkSite.Text = "See the source code";
            this.lkSite.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkSiteLinkClicked);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 104);
            this.Controls.Add(this.lkSite);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.LinkLabel lkSite;
    }
}