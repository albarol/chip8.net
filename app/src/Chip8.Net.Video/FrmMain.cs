namespace Chip8.Net.Video
{
    using System.Threading;
    using System.Windows.Forms;

    using Chip8.Net.Video.Settings;

    using CycleTimer = System.Timers.Timer;

    public partial class FrmMain : Form
    {
        private Processor processor;
        private CycleTimer cycleTimer;
        private Thread emulationCycle;
        
        public FrmMain()
        {
            this.InitializeComponent();
            this.Initialize();
        }

        private void Initialize()
        {
            this.processor = new Processor(new VideoRender(this.pbMonitor));
            this.processor.Memory.LoadRom(Loader.LoadRom(@"E:\Github\chip8.net\roms\PUZZLE.rom"));
            this.processor.Memory.LoadCharacters();


            this.emulationCycle = new Thread(EmulationCycle);
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
