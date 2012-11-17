namespace Chip8.Net.Video
{
    partial class RenderDialog
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
            this.pbMonitor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMonitor
            // 
            this.pbMonitor.Location = new System.Drawing.Point(2, 2);
            this.pbMonitor.Margin = new System.Windows.Forms.Padding(0);
            this.pbMonitor.Name = "pbMonitor";
            this.pbMonitor.Size = new System.Drawing.Size(384, 192);
            this.pbMonitor.TabIndex = 0;
            this.pbMonitor.TabStop = false;
            // 
            // RenderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(385, 194);
            this.Controls.Add(this.pbMonitor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderDialog";
            this.Text = "CHIP8";
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMonitor;
    }
}

