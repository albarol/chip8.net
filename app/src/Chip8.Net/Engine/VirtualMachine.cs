namespace Chip8.Net.Engine
{
    using System.Threading;

    using Chip8.Net.Helpers;

    public class VirtualMachine
    {
        private Thread emulationCycle;
        private bool isRunning;
        private string loadedRom;
        
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

        public Sound Sound
        {
            get
            {
                return this.Processor.Sound;
            }
        }

        public void LoadRom(string rom)
        {
            this.loadedRom = rom;
            this.Processor.Initialize();
            this.Processor.Memory.LoadRom(Loader.LoadRom(rom));
            this.Processor.Memory.LoadCharacters();
        }

        public void Reset()
        {
            this.Stop();
            Thread.Sleep(10);
            if (!string.IsNullOrEmpty(this.loadedRom))
            {
                this.LoadRom(this.loadedRom);
                this.Run();
            }
        }

        public void Stop()
        {
            if (this.isRunning)
            {
                this.isRunning = false;
                this.emulationCycle.Abort();
                this.Render.Clear();
                this.Render.DrawFrame();
            }
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
