namespace Chip8.Net.Video.Settings
{
    using System.Threading;

    public class VirtualMachine
    {
        private Thread emulationCycle;
        private bool isRunning = false;
        
        public VirtualMachine(Gpu render)
        {
            this.Render = render;
            this.Processor = new Processor(this.Render);
        }

        public Processor Processor { get; private set; }
        public Gpu Render { get; private set; }
        public Keyboard Keyboard
        {
            get { return this.Processor.Keyboard; }
        }
        
        public void LoadRom(string rom)
        {
            this.Processor.Initialize();
            this.Processor.Memory.LoadRom(Loader.LoadRom(rom));
            this.Processor.Memory.LoadCharacters();
        }

        public void Stop()
        {
            this.isRunning = false;
        }
        
        public void Run()
        {
            this.emulationCycle = new Thread(this.EmulationCycle);
            this.emulationCycle.Start();
        }

        private void EmulationCycle()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                this.Processor.StepRun();
            }
        }
    }
}
