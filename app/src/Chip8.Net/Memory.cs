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
                if (index > 0xFFF)
                {
                    throw new ArgumentException("Invalid access memory");
                }

                return this.memory[index];
            }
            set
            {
                if (index > 0xFFF)
                {
                    throw new ArgumentException("Invalid access memory");
                }
                this.memory[index] = value;
            }
        }

        public int Size { get { return memory.Length; } }

        public void Clear()
        {
            for (int position = 0x200; position <= 0xFFF; position++)
            {
                this.memory[position] = 0x0;
            }
        }

        public void LoadRom(int[] rom)
        {
            const int Position = 0x200;
            for (int i = 0x0; i < rom.Length; i++)
            {
                this.memory[Position + i] = rom[i];
            }
        }

        public void LoadCharacters()
        {
            this.memory[0x000] = 0xF0;
            this.memory[0x001] = 0x90;
            this.memory[0x002] = 0x90;
            this.memory[0x003] = 0x90;
            this.memory[0x004] = 0xF0;
            //1 SPRITE
            this.memory[0x005] = 0x20;
            this.memory[0x006] = 0x60;
            this.memory[0x007] = 0x20;
            this.memory[0x008] = 0x20;
            this.memory[0x009] = 0x70;
            //2 SPRITE add: 0x00A
            this.memory[0x00A] = 0xF0;
            this.memory[0x00B] = 0x10;
            this.memory[0x00C] = 0xF0;
            this.memory[0x00D] = 0x80;
            this.memory[0x00E] = 0xF0;
            //3 SPRITE add: 0x00F
            this.memory[0x00F] = 0xF0;
            this.memory[0x010] = 0x10;
            this.memory[0x011] = 0xF0;
            this.memory[0x012] = 0x10;
            this.memory[0x013] = 0xF0;
            //4 SPRITE add: 0x014
            this.memory[0x014] = 0x90;
            this.memory[0x015] = 0x90;
            this.memory[0x016] = 0xF0;
            this.memory[0x017] = 0x10;
            this.memory[0x018] = 0x10;
            //5 SPRITE add: 0x019
            this.memory[0x019] = 0xF0;
            this.memory[0x01A] = 0x80;
            this.memory[0x01B] = 0xF0;
            this.memory[0x01C] = 0x10;
            this.memory[0x01D] = 0xF0;
            //6 SPRITE add: 0x01E
            this.memory[0x01E] = 0xF0;
            this.memory[0x01F] = 0x80;
            this.memory[0x020] = 0xF0;
            this.memory[0x021] = 0x90;
            this.memory[0x022] = 0xF0;
            //7 SPRITE add: 0x023
            this.memory[0x023] = 0xF0;
            this.memory[0x024] = 0x10;
            this.memory[0x025] = 0x20;
            this.memory[0x026] = 0x40;
            this.memory[0x027] = 0x40;
            //8 SPRITE add: 0x028
            this.memory[0x028] = 0xF0;
            this.memory[0x029] = 0x90;
            this.memory[0x02A] = 0xF0;
            this.memory[0x02B] = 0x90;
            this.memory[0x02C] = 0xF0;
            //9 SPRITE add: 0x02D
            this.memory[0x02D] = 0xF0;
            this.memory[0x02E] = 0x90;
            this.memory[0x02F] = 0xF0;
            this.memory[0x030] = 0x10;
            this.memory[0x031] = 0xF0;
            //A SPRITE add: 0x032
            this.memory[0x032] = 0xF0;
            this.memory[0x033] = 0x90;
            this.memory[0x034] = 0xF0;
            this.memory[0x035] = 0x90;
            this.memory[0x036] = 0x90;
            //B SPRITE add: 0x037
            this.memory[0x037] = 0xE0;
            this.memory[0x038] = 0x90;
            this.memory[0x039] = 0xE0;
            this.memory[0x03A] = 0x90;
            this.memory[0x03B] = 0xE0;
            //C SPRITE add: 0x03C
            this.memory[0x03C] = 0xF0;
            this.memory[0x03D] = 0x80;
            this.memory[0x03E] = 0x80;
            this.memory[0x03F] = 0x80;
            this.memory[0x040] = 0xF0;
            //D SPRITE add: 0x041
            this.memory[0x041] = 0xE0;
            this.memory[0x042] = 0x90;
            this.memory[0x043] = 0x90;
            this.memory[0x044] = 0x90;
            this.memory[0x045] = 0xE0;
            //E SPRITE add: 0x046
            this.memory[0x046] = 0xF0;
            this.memory[0x047] = 0x80;
            this.memory[0x048] = 0xF0;
            this.memory[0x049] = 0x80;
            this.memory[0x04A] = 0xF0;
            //F SPRITE add: 0x04B
            this.memory[0x04B] = 0xF0;
            this.memory[0x04C] = 0x80;
            this.memory[0x04D] = 0xF0;
            this.memory[0x04E] = 0x80;
            this.memory[0x04F] = 0x80;
        }
    }
}
