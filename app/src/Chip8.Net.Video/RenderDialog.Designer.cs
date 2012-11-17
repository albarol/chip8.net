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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenderDialog));
            this.mnEmulator = new System.Windows.Forms.MenuStrip();
            this.stmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.stmLoadRom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.stmPowerOff = new System.Windows.Forms.ToolStripMenuItem();
            this.stmReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.stmSaveState = new System.Windows.Forms.ToolStripMenuItem();
            this.stmLoadState = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.stmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.stmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.stmWindowSize = new System.Windows.Forms.ToolStripMenuItem();
            this.stmSmallGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.stmLargeGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.stmEnableSound = new System.Windows.Forms.ToolStripMenuItem();
            this.stmDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.pbRender = new System.Windows.Forms.PictureBox();
            this.mnEmulator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRender)).BeginInit();
            this.SuspendLayout();
            // 
            // mnEmulator
            // 
            this.mnEmulator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmFile,
            this.stmSettings,
            this.stmDebugger});
            this.mnEmulator.Location = new System.Drawing.Point(0, 0);
            this.mnEmulator.Name = "mnEmulator";
            this.mnEmulator.Size = new System.Drawing.Size(385, 24);
            this.mnEmulator.TabIndex = 0;
            this.mnEmulator.Text = "menuStrip1";
            // 
            // stmFile
            // 
            this.stmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmLoadRom,
            this.toolStripMenuItem1,
            this.stmPowerOff,
            this.stmReset,
            this.toolStripMenuItem2,
            this.stmSaveState,
            this.stmLoadState,
            this.toolStripMenuItem3,
            this.stmExit});
            this.stmFile.Name = "stmFile";
            this.stmFile.Size = new System.Drawing.Size(37, 20);
            this.stmFile.Text = "File";
            // 
            // stmLoadRom
            // 
            this.stmLoadRom.Name = "stmLoadRom";
            this.stmLoadRom.Size = new System.Drawing.Size(130, 22);
            this.stmLoadRom.Text = "Load ROM";
            this.stmLoadRom.Click += new System.EventHandler(this.StmLoadRomClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // stmPowerOff
            // 
            this.stmPowerOff.Name = "stmPowerOff";
            this.stmPowerOff.Size = new System.Drawing.Size(130, 22);
            this.stmPowerOff.Text = "Power Off";
            this.stmPowerOff.Click += new System.EventHandler(this.StmPowerOffClick);
            // 
            // stmReset
            // 
            this.stmReset.Name = "stmReset";
            this.stmReset.Size = new System.Drawing.Size(130, 22);
            this.stmReset.Text = "Reset";
            this.stmReset.Click += new System.EventHandler(this.StmResetClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(127, 6);
            // 
            // stmSaveState
            // 
            this.stmSaveState.Name = "stmSaveState";
            this.stmSaveState.Size = new System.Drawing.Size(130, 22);
            this.stmSaveState.Text = "Save State";
            // 
            // stmLoadState
            // 
            this.stmLoadState.Name = "stmLoadState";
            this.stmLoadState.Size = new System.Drawing.Size(130, 22);
            this.stmLoadState.Text = "Load State";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(127, 6);
            // 
            // stmExit
            // 
            this.stmExit.Name = "stmExit";
            this.stmExit.Size = new System.Drawing.Size(130, 22);
            this.stmExit.Text = "Exit";
            this.stmExit.Click += new System.EventHandler(this.StmExitClick);
            // 
            // stmSettings
            // 
            this.stmSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmWindowSize,
            this.stmEnableSound});
            this.stmSettings.Name = "stmSettings";
            this.stmSettings.Size = new System.Drawing.Size(61, 20);
            this.stmSettings.Text = "Settings";
            // 
            // stmWindowSize
            // 
            this.stmWindowSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stmSmallGraphics,
            this.stmLargeGraphics});
            this.stmWindowSize.Name = "stmWindowSize";
            this.stmWindowSize.Size = new System.Drawing.Size(146, 22);
            this.stmWindowSize.Text = "Window Size";
            // 
            // stmSmallGraphics
            // 
            this.stmSmallGraphics.Name = "stmSmallGraphics";
            this.stmSmallGraphics.Size = new System.Drawing.Size(115, 22);
            this.stmSmallGraphics.Text = "64 x 32";
            this.stmSmallGraphics.Click += new System.EventHandler(this.StmSmallGraphicsClick);
            // 
            // stmLargeGraphics
            // 
            this.stmLargeGraphics.Name = "stmLargeGraphics";
            this.stmLargeGraphics.Size = new System.Drawing.Size(115, 22);
            this.stmLargeGraphics.Text = "128 x 64";
            this.stmLargeGraphics.Click += new System.EventHandler(this.StmLargeGraphicsClick);
            // 
            // stmEnableSound
            // 
            this.stmEnableSound.Name = "stmEnableSound";
            this.stmEnableSound.Size = new System.Drawing.Size(146, 22);
            this.stmEnableSound.Text = "Enable Sound";
            // 
            // stmDebugger
            // 
            this.stmDebugger.Name = "stmDebugger";
            this.stmDebugger.Size = new System.Drawing.Size(71, 20);
            this.stmDebugger.Text = "Debugger";
            // 
            // pbRender
            // 
            this.pbRender.Location = new System.Drawing.Point(0, 27);
            this.pbRender.Name = "pbRender";
            this.pbRender.Size = new System.Drawing.Size(385, 167);
            this.pbRender.TabIndex = 1;
            this.pbRender.TabStop = false;
            // 
            // RenderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(385, 194);
            this.Controls.Add(this.pbRender);
            this.Controls.Add(this.mnEmulator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnEmulator;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderDialog";
            this.Text = "CHIP8.NET";
            this.mnEmulator.ResumeLayout(false);
            this.mnEmulator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnEmulator;
        private System.Windows.Forms.ToolStripMenuItem stmFile;
        private System.Windows.Forms.ToolStripMenuItem stmLoadRom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stmPowerOff;
        private System.Windows.Forms.ToolStripMenuItem stmReset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem stmSaveState;
        private System.Windows.Forms.ToolStripMenuItem stmLoadState;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem stmExit;
        private System.Windows.Forms.ToolStripMenuItem stmSettings;
        private System.Windows.Forms.ToolStripMenuItem stmWindowSize;
        private System.Windows.Forms.ToolStripMenuItem stmSmallGraphics;
        private System.Windows.Forms.ToolStripMenuItem stmLargeGraphics;
        private System.Windows.Forms.ToolStripMenuItem stmEnableSound;
        private System.Windows.Forms.ToolStripMenuItem stmDebugger;
        private System.Windows.Forms.PictureBox pbRender;

    }
}

