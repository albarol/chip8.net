namespace Chip8.Net.Core
{
    using System;

    public class Processor
    {
        private Memory memory;
        private byte[] registerV;

        private Stack stack;
        
        public Processor()
        {
            this.memory = new Memory();
            this.ProgramCounter = 0x200;
            this.registerV = new byte[0xF];
            this.stack = new Stack();
        }

        public short ProgramCounter { get; private set; }

        public void InterpretOpcode(short opcode)
        {
            switch (opcode & 0xF000)
            {
                case Instructions.JumpTo:
                    this.JumpTo(opcode);
                    break;
                case Instructions.CallRoutine:
                    this.CallRoutine(opcode);
                    break;
                case Instructions.SkipNextRegisterEqualAddress:
                    this.SkipNextRegisterEqualAddress(opcode);
                    break;
            }
        }

        private void JumpTo(short opcode)
        {
            short address = Convert.ToInt16(opcode & 0x0FFF);
            this.ProgramCounter = address;
        }

        private void CallRoutine(short opcode)
        {
            short address = Convert.ToInt16(opcode & 0x0FFF);
            this.stack.Push(this.ProgramCounter);
            this.ProgramCounter = address;
        }

        private void SkipNextRegisterEqualAddress(short opcode)
        {
            short register = Convert.ToInt16(opcode & 0x0F00);
            short position = Convert.ToInt16(opcode & 0x00FF);
            if (this.registerV[register] == position)
            {
                this.ProgramCounter += 0x2;
            }
        }
    }
}
