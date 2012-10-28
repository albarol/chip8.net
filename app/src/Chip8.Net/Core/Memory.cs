namespace Chip8.Net.Core
{
    using System;

    public class Memory
    {
        private readonly byte[] memory = new byte[4096];

        public byte this[int index]
        {
            get
            {
                if (index < 0x200 || index > 0xFFF)
                {
                    throw new ArgumentException("Invalid access memory");
                }

                return this.memory[index];
            }
            set
            {
                if (index < 0x200 || index > 0xFFF)
                {
                    throw new ArgumentException("Invalid access memory");
                }
                this.memory[index] = value;
            }
        }

        public void Clear()
        {
            for (int position = 0x200; position <= 0xFFF; position++)
            {
                this.memory[position] = 0x0;
            }
        }
    }
}
