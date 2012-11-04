namespace Chip8.Net.Core
{
    using System;

    public class Processor
    {
        private readonly Stack stack;

        public Processor()
        {
            this.Memory = new Memory();
            this.ProgramCounter = 0x200;
            this.RegisterV = new Register(0xF);
            this.stack = new Stack();
        }

        public Memory Memory { get; private set; }
        public Register RegisterV { get; private set; }

        public int ProgramCounter { get; private set; }

        public void StepRun()
        {
            var opcode = this.Memory[this.ProgramCounter];
            this.InterpretOpcode(opcode);
        }

        private void InterpretOpcode(int opcode)
        {
            switch (opcode & 0xF000)
            {
                case Instructions.JumpTo:
                    this.JumpTo(opcode);
                    break;
                case Instructions.CallRoutine:
                    this.CallRoutine(opcode);
                    break;
                case Instructions.SkipNextRegisterVxEqualAddress:
                    this.SkipNextRegisterVxEqualAddress(opcode);
                    break;
                case Instructions.SkipNextRegisterVxNotEqualAddress:
                    this.SkipNextRegisterVxNotEqualAddress(opcode);
                    break;
                case Instructions.SkipNextRegisterVxNotEqualVy:
                    this.SkipNextRegisterVxNotEqualVy(opcode);
                    break;
                case Instructions.SetVxToNn:
                    this.SetVxToNn(opcode);
                    break;
                case Instructions.AddNnToVx:
                    this.AddNnToVx(opcode);
                    break;
            }
        }

        private void JumpTo(int opcode)
        {
            int address = opcode & 0x0FFF;
            this.ProgramCounter = address;
        }

        private void CallRoutine(int opcode)
        {
            int address = opcode & 0x0FFF;
            this.stack.Push(this.ProgramCounter);
            this.ProgramCounter = address;
        }

        private void SkipNextRegisterVxEqualAddress(int opcode)
        {
            int position = opcode & 0x00FF;
            int register = (opcode & 0x0F00) >> 8;
            
            if (this.RegisterV[register] == position)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipNextRegisterVxNotEqualAddress(int opcode)
        {
            int position = opcode & 0x00FF;
            int register = (opcode & 0x0F00) >> 8;

            if (this.RegisterV[register] != position)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipNextRegisterVxNotEqualVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4;

            if (this.RegisterV[positionX] != this.RegisterV[positionY])
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SetVxToNn(int opcode)
        {
            int position = opcode & 0x00FF;
            int register = (opcode & 0x0F00) >> 8;
            this.RegisterV[register] = position;
        }

        private void AddNnToVx(int opcode)
        {
            int position = opcode & 0x00FF;
            int register = (opcode & 0x0F00) >> 8;
            this.RegisterV[register] += position;
        }
    }
}
