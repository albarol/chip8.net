namespace Chip8.Net.Engine
{
    using System.IO;
	using System.Media;

    public class Sound
    {
        private SoundPlayer audio;
        private byte[] bufferAudio;
        
        public Sound()
        {
            this.Enabled = true;
            this.LoadAudio();
        }

        public int Timer { get; set; }
        public bool Enabled { get; set; }

        public void Beep()
        {
			this.audio.Play();
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
			using (var beepAudio = new MemoryStream(buffer))
            {
				this.audio = new SoundPlayer(beepAudio);
            }
        }
    }
}
