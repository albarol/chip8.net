namespace Chip8.Net.Engine
{
    using System;
    using System.Threading;

    using Chip8.Net.Helpers;

    public class VirtualMachine
    {
        private Thread emulationCycle;
        private string loadedRom;
        
        public VirtualMachine(Gpu render)
        {
            this.Render = render;
            this.Processor = new Processor(this.Render);
            this.ProcessingStatus = ProcessingStatus.Stopped;
            
        }

        public ProcessingStatus ProcessingStatus { get; private set; }
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
            if (this.ProcessingStatus == ProcessingStatus.Running)
            {
                this.Pause();
            }
            
            this.Render.Clear();
            this.Render.DrawFrame();
            Thread.Sleep(10);
            if (!string.IsNullOrEmpty(this.loadedRom))
            {
                this.LoadRom(this.loadedRom);
                this.Run();
            }
        }

        public void Pause()
        {
            if (this.ProcessingStatus == ProcessingStatus.Running)
            {
                this.ProcessingStatus = ProcessingStatus.Paused;
                this.emulationCycle.Abort();
                Thread.Sleep(20);
            }
        }

        public void Stop()
        {
            if (this.ProcessingStatus == ProcessingStatus.Running)
            {
                this.Pause();
            }

            this.ProcessingStatus = ProcessingStatus.Stopped;
            this.Render.Clear();
            this.Render.DrawFrame();
            this.Processor.Initialize();
            this.loadedRom = null;
        }
        
        public void Run()
        {
            if (!string.IsNullOrEmpty(this.loadedRom))
            {
                this.ProcessingStatus = ProcessingStatus.Running;
                this.emulationCycle = new Thread(this.EmulationCycle);
                this.emulationCycle.Start();
            }
        }

        public void SaveState()
        {
        }

        public void LoadState()
        {
        }

        private void EmulationCycle()
        {
            while (this.ProcessingStatus == ProcessingStatus.Running)
            {
                this.Processor.StepRun();
            }    
        }
    }
}
