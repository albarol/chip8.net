﻿namespace Chip8.Net.Core
{
    public class Processor
    {
        public Processor()
        {
            this.Memory = new Memory();
            this.ProgramCounter = 0x200;
            this.RegisterV = new Register(0x10);
            this.Stack = new Stack();
        }

        public Memory Memory { get; private set; }
        public Register RegisterV { get; private set; }
        public Stack Stack { get; private set; }
        public int RegisterI { get; private set; }

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
            else if ((opcode & 0xF000) == Instructions.SkipNextRegisterVxEqualVy)
            {
                this.SkipNextRegisterVxEqualVy(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SetVxToNn)
            {
                this.SetVxToNn(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.AddNnToVx)
            {
                this.AddNnToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SetVxToVy)
            {
                this.SetVxToVy(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SetVxToVxOrVy)
            {
                this.SetVxToVxOrVy(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SetVxToVxAndVy)
            {
                this.SetVxToVxAndVy(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SetVxToVxXorVy)
            {
                this.SetVxToVxXorVy(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.AddVyToVx)
            {
                this.AddVyToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SubtractVyFromVx)
            {
                this.SubtractVyToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.ShiftVxRightByOne)
            {
                this.ShiftVxRightByOne(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.SetVxToVyMinusVx)
            {
                this.SetVxToVyMinusVx(opcode);
            }
            else if ((opcode & 0xF00F) == Instructions.ShiftVxLeftByOne)
            {
                this.ShiftVxLeftByOne(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SkipNextRegisterVxNotEqualVy)
            {
                this.SkipNextRegisterVxNotEqualVy(opcode);
            }
            else if ((opcode & 0xF000) == Instructions.SetIToAddressNnn)
            {
                this.SetIToAddressNnn(opcode);
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
            this.Stack.Push(this.ProgramCounter);
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

        private void SkipNextRegisterVxEqualVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4;

            if (this.RegisterV[positionX] == this.RegisterV[positionY])
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

        private void SetVxToVxOrVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4 & 0x0F;
            this.RegisterV[positionX] = this.RegisterV[positionX] | this.RegisterV[positionY];
        }

        private void SetVxToVxAndVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4 & 0x0F;
            this.RegisterV[positionX] = this.RegisterV[positionX] & this.RegisterV[positionY];
        }

        private void SetVxToVxXorVy(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4 & 0x0F;
            this.RegisterV[positionX] = this.RegisterV[positionX] ^ this.RegisterV[positionY];
        }

        private void AddVyToVx(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4 & 0x0F;

            this.RegisterV[Carry] = (this.RegisterV[positionX] + this.RegisterV[positionY] > 0xFF) ? 0x1 : 0x0;
            this.RegisterV[positionX] = (this.RegisterV[positionX] + this.RegisterV[positionY]) & 0xFF;
        }

        private void SubtractVyToVx(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4 & 0x0F;

            this.RegisterV[Carry] = (this.RegisterV[positionX] > this.RegisterV[positionY]) ? 0x1 : 0x0;
            this.RegisterV[positionX] = this.RegisterV[positionX] - this.RegisterV[positionY];
        }

        private void ShiftVxRightByOne(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;

            this.RegisterV[Carry] = (this.RegisterV[positionX] & 0x1) == 0x1 ? 0x1 : 0x0;
            this.RegisterV[positionX] = this.RegisterV[positionX] >> 0x1;
        }

        private void SetVxToVyMinusVx(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4;

            this.RegisterV[Carry] = (this.RegisterV[positionY] >= this.RegisterV[positionX]) ? 0x1 : 0x0;
            this.RegisterV[positionX] = this.RegisterV[positionY] - this.RegisterV[positionY];
        }

        private void ShiftVxLeftByOne(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;

            this.RegisterV[Carry] = (this.RegisterV[positionX] >> 0x7) == 0x1 ? 0x1 : 0x0;
            this.RegisterV[positionX] = this.RegisterV[positionX] << 0x1 & 0xFF;
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

        private void SetIToAddressNnn(int opcode)
        {
            int place = opcode & 0x0FFF;
            this.RegisterI = place;
        }
    }
}
