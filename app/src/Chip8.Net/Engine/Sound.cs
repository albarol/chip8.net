namespace Chip8.Net.Engine
{
    using System.IO;

    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.Devices;

    public class Sound
    {
        private Audio audio;
        private byte[] bufferAudio;
        
        public Sound()
        {
            this.Enabled = true;
            this.audio = new Audio();
            this.bufferAudio = this.LoadAudio();
        }

        public int Timer { get; set; }
        public bool Enabled { get; set; }

        public void Beep()
        {
            
            using (var beepAudio = new MemoryStream(this.bufferAudio))
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


        private byte[] LoadAudio()
        {
            byte[] buffer;
            using (var reader = new BinaryReader(typeof(Sound).Assembly.GetManifestResourceStream("Chip8.Net.Assets.beep.wav")))
            {
                buffer = new byte[(int)reader.BaseStream.Length];
                reader.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }
    }
}
