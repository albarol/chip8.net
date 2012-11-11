namespace Chip8.Net.Video
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    using Chip8.Net.Video.Settings;

    using CycleTimer = System.Timers.Timer;

    public partial class FrmMain : Form
    {
        private Processor processor;
        private CycleTimer cycleTimer;
        private Thread thread;
        
        public FrmMain()
        {
            this.InitializeComponent();
            this.Initialize();
        }

        private void Initialize()
        {
            this.processor = new Processor(new VideoRender(this.pbMonitor));
            this.processor.Memory.LoadRom(Loader.LoadRom(@"E:\Github\chip8.net\roms\INVADERS.rom"));
            this.processor.Memory.LoadCharacters();

            this.cycleTimer = new CycleTimer
            {
                Enabled = true,
                Interval = 1,
                AutoReset = true
            };
            this.cycleTimer.Elapsed += this.CycleProcess;
            this.KeyPress += this.FrmKeyPress;
            //this.KeyUp += this.FrmKeyRelease;
        }

        //private void FrmKeyRelease(object sender, KeyEventArgs e)
        //{
        //    this.processor.Keyboard.ReleaseKey();
        //}

        private void FrmKeyPress(object sender, KeyPressEventArgs e)
        {
            this.processor.Keyboard.PressKey(e.KeyChar);
        }

        private void CycleProcess(object sender, ElapsedEventArgs e)
        {
            this.cycleTimer.Stop();
            this.processor.StepRun();
            this.cycleTimer.Start();
        }
    }
}
