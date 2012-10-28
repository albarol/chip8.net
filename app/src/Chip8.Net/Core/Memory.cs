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
    }
}
