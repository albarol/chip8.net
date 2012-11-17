namespace Chip8.Net
{
    using System;

    public class Sound
    {
        public Sound()
        {
            this.Enabled = true;
        }

        public int Timer { get; set; }
        public bool Enabled { get; set; }

        public void Beep()
        {
            Console.Beep();    
        }

        public void Update()
        {
            if (this.Timer > 0)
            {
                if (this.Timer == 1 && this.Enabled)
                {
                    Console.Beep();
                }
                this.Timer -= 1;
            }
        }
    }
}
