namespace Chip8.Net.Core
{
    using System;

    public class Register
    {
        private readonly int[] register;

        public Register(int size)
        {
            this.register = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0x0 || index > this.register.Length)
                {
                    throw new ArgumentException("Invalid access memory");
                }

                return this.register[index];
            }
            set
            {
                if (index < 0x0 || index > this.register.Length)
                {
                    throw new ArgumentException("Invalid access memory");
                }
                this.register[index] = value;
            }
        }

        public void Clear()
        {
            for (int position = 0x200; position <= this.register.Length; position++)
            {
                this.register[position] = 0x0;
            }
        }
    }
}
