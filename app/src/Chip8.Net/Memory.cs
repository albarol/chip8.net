namespace Chip8.Net
{
    using System;

    public class Memory
    {
        private readonly int[] memory = new int[0x1000];

        internal Memory()
        {
        }

        public int this[int index]
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
