namespace Chip8.Net
{
    using System;
    using System.Text;

    public class Register
    {
        private readonly byte[] register;

        public Register(int size)
        {
            this.register = new byte[size];
        }

        public byte this[int index]
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
            for (int position = 0x0; position <= this.register.Length; position++)
            {
                this.register[position] = 0x0;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder("{");
            for (int i = 0; i < this.register.Length; i++)
            {
                builder.AppendFormat("{0}, ", this.register[i]);
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
