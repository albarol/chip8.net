#define MONO

namespace Chip8.Net
{
    using System;
    using System.Windows.Forms;

    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void LkSiteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OpenUrl("https://github.com/fakeezz/chip8.net");
        }

        private void OpenUrl(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch
            {
                MessageBox.Show(string.Format("See in website: {0}", url), "Chip-8.Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
