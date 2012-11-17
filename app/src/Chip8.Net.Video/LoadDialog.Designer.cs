namespace Chip8.Net.Video
{
    partial class LoadDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDialog));
            this.lbRom = new System.Windows.Forms.Label();
            this.tbRom = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.rbLargeGraphics = new System.Windows.Forms.RadioButton();
            this.rbSmallGraphics = new System.Windows.Forms.RadioButton();
            this.btLoad = new System.Windows.Forms.Button();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRom
            // 
            this.lbRom.AutoSize = true;
            this.lbRom.Location = new System.Drawing.Point(13, 13);
            this.lbRom.Name = "lbRom";
            this.lbRom.Size = new System.Drawing.Size(32, 13);
            this.lbRom.TabIndex = 0;
            this.lbRom.Text = "Rom:";
            // 
            // tbRom
            // 
            this.tbRom.Enabled = false;
            this.tbRom.Location = new System.Drawing.Point(16, 30);
            this.tbRom.Name = "tbRom";
            this.tbRom.Size = new System.Drawing.Size(354, 20);
            this.tbRom.TabIndex = 1;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(294, 56);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 2;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.BtRunClick);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.rbLargeGraphics);
            this.gbSettings.Controls.Add(this.rbSmallGraphics);
            this.gbSettings.Location = new System.Drawing.Point(16, 100);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(354, 138);
            this.gbSettings.TabIndex = 3;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Graphics";
            // 
            // rbLargeGraphics
            // 
            this.rbLargeGraphics.AutoSize = true;
            this.rbLargeGraphics.Location = new System.Drawing.Point(7, 44);
            this.rbLargeGraphics.Name = "rbLargeGraphics";
            this.rbLargeGraphics.Size = new System.Drawing.Size(66, 17);
            this.rbLargeGraphics.TabIndex = 1;
            this.rbLargeGraphics.Text = "128 x 64";
            this.rbLargeGraphics.UseVisualStyleBackColor = true;
            // 
            // rbSmallGraphics
            // 
            this.rbSmallGraphics.AutoSize = true;
            this.rbSmallGraphics.Checked = true;
            this.rbSmallGraphics.Location = new System.Drawing.Point(7, 20);
            this.rbSmallGraphics.Name = "rbSmallGraphics";
            this.rbSmallGraphics.Size = new System.Drawing.Size(60, 17);
            this.rbSmallGraphics.TabIndex = 0;
            this.rbSmallGraphics.TabStop = true;
            this.rbSmallGraphics.Text = "64 x 32";
            this.rbSmallGraphics.UseVisualStyleBackColor = true;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(213, 56);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 4;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.BtLoadClick);
            // 
            // LoadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 250);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.tbRom);
            this.Controls.Add(this.lbRom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadDialog";
            this.Text = "CHIP8.NET";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRom;
        private System.Windows.Forms.TextBox tbRom;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.RadioButton rbLargeGraphics;
        private System.Windows.Forms.RadioButton rbSmallGraphics;
        private System.Windows.Forms.Button btLoad;
    }
}