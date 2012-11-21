namespace Chip8.Net.Engine
{
    using System.IO;

    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.Devices;

    public class Sound
    {
        private Audio audio;
        
        public Sound()
        {
            this.Enabled = true;
            this.audio = new Audio();
        }

        public int Timer { get; set; }
        public bool Enabled { get; set; }

        public void Beep()
        {
            using (var beepAudio = typeof(Sound).Assembly.GetManifestResourceStream("Chip8.Net.Assets.beep.wav"))
            {
                this.audio.Play(beepAudio, AudioPlayMode.Background);    
            }
        }

        public void Update()
        {
            if (this.Timer > 0)
            {
                if (this.Timer == 1 && this.Enabled)
                {
                    this.Beep();
                }
                this.Timer -= 1;
            }
        }
    }
}
