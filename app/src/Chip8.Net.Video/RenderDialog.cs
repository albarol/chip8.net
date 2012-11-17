namespace Chip8.Net.Video
{
    using System.Threading;
    using System.Windows.Forms;

    using Chip8.Net.Video.Settings;

    public partial class RenderDialog : Form
    {
        private Processor processor;
        private Thread emulationCycle;
        
        public RenderDialog(string romName, Graphics graphics)
        {
            this.InitializeComponent();
            this.Initialize(romName, graphics);
        }

        private void Initialize(string romName, Graphics graphics)
        {
            this.Size = graphics.WindowSize;
            this.pbMonitor.Size = graphics.RenderSize;
            this.processor = new Processor(new VideoRender(this.pbMonitor, graphics.Pixel));
            this.processor.Memory.LoadRom(Loader.LoadRom(romName));
            this.processor.Memory.LoadCharacters();


            this.emulationCycle = new Thread(this.EmulationCycle);
            this.emulationCycle.Start();
            this.KeyDown += this.FrmKeyDown;
            this.KeyUp += this.FrmKeyUp;
        }

        private void FrmKeyUp(object sender, KeyEventArgs e)
        {
            char key = (char)e.KeyData;
            this.processor.Keyboard.ReleaseKey(key);
        }

        private void FrmKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.KeyData;
            this.processor.Keyboard.PressKey(key);
        }

        private void EmulationCycle()
        {
            while (true)
            {
                this.processor.StepRun();
                // Thread.Sleep(6);
            }
        }
    }
}
