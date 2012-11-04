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
            if (opcode == Instructions.ClearScreen)
            {
                return;
            }
            else if (opcode == Instructions.ReturnRoutine)
            {
                
            }
            else if ((opcode & 0xF000) == Instructions.JumpTo)
            {
                this.JumpTo(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.CallRoutine)
            {
                this.CallRoutine(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SkipNextRegisterVxEqualAddress)
            {
                this.SkipNextRegisterVxEqualAddress(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SkipNextRegisterVxNotEqualAddress)
            {
                this.SkipNextRegisterVxNotEqualAddress(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SkipNextRegisterVxNotEqualVy)
            {
                this.SkipNextRegisterVxNotEqualVy(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SetVxToNn)
            {
                this.SetVxToNn(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.AddNnToVx)
            {
                this.AddNnToVx(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SetVxToVy)
            {
                this.SetVxToVy(opcode);
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

        private void SetVxToVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4;
            this.RegisterV[positionX] = this.RegisterV[positionY];
        }
    }
}
