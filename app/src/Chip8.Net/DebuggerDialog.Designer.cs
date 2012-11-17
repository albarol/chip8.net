namespace Chip8.Net
{
    partial class DebuggerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebuggerDialog));
            this.tcItems = new System.Windows.Forms.TabControl();
            this.tbpMemory = new System.Windows.Forms.TabPage();
            this.tbpRegisters = new System.Windows.Forms.TabPage();
            this.dtgMemory = new System.Windows.Forms.DataGridView();
            this.tcItems.SuspendLayout();
            this.tbpMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMemory)).BeginInit();
            this.SuspendLayout();
            // 
            // tcItems
            // 
            this.tcItems.Controls.Add(this.tbpMemory);
            this.tcItems.Controls.Add(this.tbpRegisters);
            this.tcItems.Location = new System.Drawing.Point(1, 1);
            this.tcItems.Name = "tcItems";
            this.tcItems.SelectedIndex = 0;
            this.tcItems.Size = new System.Drawing.Size(427, 256);
            this.tcItems.TabIndex = 0;
            // 
            // tbpMemory
            // 
            this.tbpMemory.Controls.Add(this.dtgMemory);
            this.tbpMemory.Location = new System.Drawing.Point(4, 22);
            this.tbpMemory.Name = "tbpMemory";
            this.tbpMemory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMemory.Size = new System.Drawing.Size(419, 230);
            this.tbpMemory.TabIndex = 0;
            this.tbpMemory.Text = "Memory";
            this.tbpMemory.UseVisualStyleBackColor = true;
            // 
            // tbpRegisters
            // 
            this.tbpRegisters.Location = new System.Drawing.Point(4, 22);
            this.tbpRegisters.Name = "tbpRegisters";
            this.tbpRegisters.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegisters.Size = new System.Drawing.Size(419, 230);
            this.tbpRegisters.TabIndex = 1;
            this.tbpRegisters.Text = "Registers";
            this.tbpRegisters.UseVisualStyleBackColor = true;
            // 
            // dtgMemory
            // 
            this.dtgMemory.AllowUserToAddRows = false;
            this.dtgMemory.AllowUserToDeleteRows = false;
            this.dtgMemory.AllowUserToResizeColumns = false;
            this.dtgMemory.AllowUserToResizeRows = false;
            this.dtgMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMemory.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtgMemory.Location = new System.Drawing.Point(3, 3);
            this.dtgMemory.MultiSelect = false;
            this.dtgMemory.Name = "dtgMemory";
            this.dtgMemory.ReadOnly = true;
            this.dtgMemory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgMemory.Size = new System.Drawing.Size(217, 224);
            this.dtgMemory.TabIndex = 0;
            // 
            // DebuggerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 256);
            this.Controls.Add(this.tcItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebuggerDialog";
            this.Text = "Chip8.NET :: Debugger";
            this.tcItems.ResumeLayout(false);
            this.tbpMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMemory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcItems;
        private System.Windows.Forms.TabPage tbpMemory;
        private System.Windows.Forms.TabPage tbpRegisters;
        private System.Windows.Forms.DataGridView dtgMemory;
    }
}