namespace Chip8.Net.Video
{
    using System;
    using System.Windows.Forms;

    using Chip8.Net.Video.Settings;

    public partial class LoadDialog : Form
    {
        public LoadDialog()
        {
            this.InitializeComponent();
        }

        private void BtLoadClick(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Rom Files (*.rom)|*.rom"
            };
            openDialog.FileOk += (o, args) =>
            {
                tbRom.Text = openDialog.FileName;            
            };
            openDialog.ShowDialog();
        }

        private void BtRunClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbRom.Text))
            {
                return;
            }

            Graphics graphics = rbLargeGraphics.Checked ? Graphics.Large() : Graphics.Small();
            RenderDialog render = new RenderDialog(tbRom.Text, graphics);
            render.Show();
        }
    }
}
