namespace Chip8.Net
{
    using System;
    using System.Collections.Generic;

    public class Processor
    {
        private int delayTimer;
        
        private Stack<ushort> stack;

        public Processor(Gpu gpu)
        {
            this.Gpu = gpu;
            this.Keyboard = new Keyboard();
            this.Initialize();
        }
        
        public Sound Sound { get; private set; }
        public Memory Memory { get; private set; }
        public Register RegisterV { get; private set; }
        public int RegisterI { get; private set; }
        public Gpu Gpu { get; private set; }
        public Keyboard Keyboard { get; private set; }

        public int ProgramCounter { get; private set; }

        public void Initialize()
        {
            this.delayTimer = 0x0;
            this.Sound = new Sound();
            this.stack = new Stack<ushort>(12);
            this.Memory = new Memory();
            this.ProgramCounter = 0x200;
            this.RegisterV = new Register(0x10);
            this.RegisterI = 0x0;
        }

        public void StepRun()
        {
            var instruction = Decoder.DecodeOpcode(this.Memory[this.ProgramCounter], this.Memory[this.ProgramCounter + 1]);
            this.ProgramCounter += 2;
            this.InterpretOpcode(instruction);

            // update timers
            if (this.delayTimer > 0)
            {
                this.delayTimer -= 1;    
            }

            this.Sound.Update();
        }

        private void InterpretOpcode(Instruction instruction)
        {
            if (instruction.Opcode == Opcodes.ClearScreen)
            {
                Gpu.Clear();
            }
            else if (instruction.Opcode == Opcodes.ReturnRoutine)
            {
                this.ReturnRoutine();
            }
            else if (instruction.Opcode == Opcodes.JumpTo)
            {
                this.JumpTo(instruction);
            }
            else if (instruction.Opcode == Opcodes.CallRoutine)
            {
                this.CallRoutine(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipNextRegisterVxEqualAddress)
            {
                this.SkipNextRegisterVxEqualAddress(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipNextRegisterVxNotEqualAddress)
            {
                this.SkipNextRegisterVxNotEqualAddress(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipNextRegisterVxEqualVy)
            {
                this.SkipNextRegisterVxEqualVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToNn)
            {
                this.SetVxToNn(instruction);
            }
            else if (instruction.Opcode == Opcodes.AddNnToVx)
            {
                this.AddNnToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToVy)
            {
                this.SetVxToVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToVxOrVy)
            {
                this.SetVxToVxOrVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToVxAndVy)
            {
                this.SetVxToVxAndVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToVxXorVy)
            {
                this.SetVxToVxXorVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.AddVyToVx)
            {
                this.AddVyToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.SubtractVyFromVx)
            {
                this.SubtractVyToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.ShiftVxRightByOne)
            {
                this.ShiftVxRightByOne(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToVyMinusVx)
            {
                this.SetVxToVyMinusVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.ShiftVxLeftByOne)
            {
                this.ShiftVxLeftByOne(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipNextRegisterVxNotEqualVy)
            {
                this.SkipNextRegisterVxNotEqualVy(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetIToAddressNnn)
            {
                this.SetIToAddressNnn(instruction);
            }
            else if (instruction.Opcode == Opcodes.JumpToPlusV0)
            {
                this.JumpToPlusV0(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxRandomNumberAndNn)
            {
                this.SetVxRandomNumberAndNn(instruction);
            }
            else if (instruction.Opcode == Opcodes.DrawSprite)
            {
                this.DrawSprite(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipIfKeyInVxPressed)
            {
                this.SkipIfKeyInVxPressed(instruction);
            }
            else if (instruction.Opcode == Opcodes.SkipIfKeyInVxNotPressed)
            {
                this.SkipIfKeyInVxNotPressed(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetVxToDelayTimer)
            {
                this.SetVxToDelayTimer(instruction);
            }
            else if (instruction.Opcode == Opcodes.StoreWaitingKeyInVx)
            {
                this.StoreWaitingKeyInVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetDelayTimerToVx)
            {
                this.SetDelayTimerToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetSoundTimerToVx)
            {
                this.SetSoundTimerToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.AddVxToI)
            {
                this.AddVxToI(instruction);
            }
            else if (instruction.Opcode == Opcodes.SetIToCharacterVx)
            {
                this.SetIToCharacterVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.StoreInVxDecimalRegisterI)
            {
                this.StoreInVxDecimalRegisterI(instruction);
            }
            else if (instruction.Opcode == Opcodes.StoreV0ToVx)
            {
                this.StoreV0ToVx(instruction);
            }
            else if (instruction.Opcode == Opcodes.FillV0ToVxFromMemory)
            {
                this.FillV0ToVxFromMemory(instruction);
            }
        }

        private void ReturnRoutine()
        {
            if (this.stack.Count > 0)
            {
                this.ProgramCounter = this.stack.Pop();
            }
            else
            {
                this.ProgramCounter = 0x200;
            }
        }

        private void JumpTo(Instruction instruction)
        {
            this.ProgramCounter = instruction.Nnn;
        }

        private void CallRoutine(Instruction instruction)
        {
            this.stack.Push((ushort)this.ProgramCounter);
            this.ProgramCounter = instruction.Nnn;
        }

        private void SkipNextRegisterVxEqualAddress(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] == instruction.Nn)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipNextRegisterVxNotEqualAddress(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] != instruction.Nn)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipNextRegisterVxEqualVy(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] == this.RegisterV[instruction.Y])
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SetVxToNn(Instruction instruction)
        {
            this.RegisterV[instruction.X] = (byte)instruction.Nn;
        }

        private void AddNnToVx(Instruction instruction)
        {
            this.RegisterV[instruction.X] += (byte)instruction.Nn;
        }

        private void SetVxToVy(Instruction instruction)
        {
            this.RegisterV[instruction.X] = this.RegisterV[instruction.Y];
        }

        private void SetVxToVxOrVy(Instruction instruction)
        {
            this.RegisterV[instruction.X] |= this.RegisterV[instruction.Y];
            this.RegisterV[0xF] = 0;
        }

        private void SetVxToVxAndVy(Instruction instruction)
        {
            this.RegisterV[instruction.X] &= this.RegisterV[instruction.Y];
            this.RegisterV[0xF] = 0;
        }

        private void SetVxToVxXorVy(Instruction instruction)
        {
            this.RegisterV[instruction.X] ^= this.RegisterV[instruction.Y];
            this.RegisterV[0xF] = 0;
        }

        private void AddVyToVx(Instruction instruction)
        {
            const int Carry = 0xF;
            int result = this.RegisterV[instruction.X] + this.RegisterV[instruction.Y];

            this.RegisterV[Carry] = (byte)((result > (int)byte.MaxValue) ? 0x1 : 0x0);
            this.RegisterV[instruction.X] = (byte)result;
        }

        private void SubtractVyToVx(Instruction instruction)
        {
            const int Carry = 0xF;
            this.RegisterV[Carry] = (byte)((this.RegisterV[instruction.X] > this.RegisterV[instruction.Y]) ? 0x1 : 0x0);
            this.RegisterV[instruction.X] -= this.RegisterV[instruction.Y];
        }

        private void ShiftVxRightByOne(Instruction instruction)
        {
            const int Carry = 0xF;
            this.RegisterV[Carry] = (byte)((this.RegisterV[instruction.X] & 0x1) == 0x1 ? 0x1 : 0x0);
            this.RegisterV[instruction.X] /= 2;
        }

        private void SetVxToVyMinusVx(Instruction instruction)
        {
            const int Carry = 0xF;
            this.RegisterV[Carry] = (byte)((this.RegisterV[instruction.Y] >= this.RegisterV[instruction.X]) ? 0x1 : 0x0);
            this.RegisterV[instruction.X] = (byte)(this.RegisterV[instruction.Y] - this.RegisterV[instruction.X]);
        }

        private void ShiftVxLeftByOne(Instruction instruction)
        {
            const int Carry = 0xF;
            this.RegisterV[Carry] = (byte)((this.RegisterV[instruction.X] & 0x80) >> 7 == 0x1 ? 0x1 : 0x0);
            this.RegisterV[instruction.X] *= 2;
        }

        private void SkipNextRegisterVxNotEqualVy(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] != this.RegisterV[instruction.Y])
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SetIToAddressNnn(Instruction instruction)
        {
            this.RegisterI = instruction.Nnn;
        }

        private void JumpToPlusV0(Instruction instruction)
        {
            this.ProgramCounter = (ushort)(instruction.Nnn + this.RegisterV[0x0]);
        }

        private void SetVxRandomNumberAndNn(Instruction instruction)
        {
            var rnd = new Random(System.Environment.TickCount);
            this.RegisterV[instruction.X] = (byte)(rnd.Next(255) & instruction.Nn);
        }

        private void DrawSprite(Instruction instruction)
        {
            const int Carry = 0xF;
            int size = instruction.N;

            int[] sprite = new int[size];
            int count = 0;
            for (int index = this.RegisterI; index < (this.RegisterI + size); index++)
            {
                sprite[count++] = this.Memory[index];
            }
            this.RegisterV[Carry] = (byte)this.Gpu.Draw(this.RegisterV[instruction.X], this.RegisterV[instruction.Y], sprite);
            this.Gpu.DrawFrame();
        }

        private void SkipIfKeyInVxPressed(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] == Keyboard.LastPressedKey)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipIfKeyInVxNotPressed(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] != Keyboard.LastPressedKey)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SetVxToDelayTimer(Instruction instruction)
        {
            if (this.delayTimer < 0)
            {
                this.delayTimer = 0;
            }

            this.RegisterV[instruction.X] = (byte)this.delayTimer;
        }

        private void StoreWaitingKeyInVx(Instruction instruction)
        {
            var keyPressed = this.Keyboard.WaitingForKey();
            if (keyPressed > -1)
            {
                this.RegisterV[instruction.X] = (byte)keyPressed;
            }
        }

        private void SetDelayTimerToVx(Instruction instruction)
        {
            this.delayTimer = this.RegisterV[instruction.X];
        }

        private void SetSoundTimerToVx(Instruction instruction)
        {
            this.Sound.Timer = this.RegisterV[instruction.X];
        }

        private void AddVxToI(Instruction instruction)
        {
            if (this.RegisterI + this.RegisterV[instruction.X] >= 0x1000)
            {
                this.RegisterI = (ushort)Memory.Size;
                this.RegisterV[0xF] = 1;
            }
            else
            {
                this.RegisterI += this.RegisterV[instruction.X];
            }
        }
        
        private void SetIToCharacterVx(Instruction instruction)
        {
            this.RegisterI = this.RegisterV[instruction.X] * 5;
        }

        private void StoreInVxDecimalRegisterI(Instruction instruction)
        {
            byte val = this.RegisterV[instruction.X];
            this.Memory[this.RegisterI] = (byte)(val / 100);
            this.Memory[this.RegisterI + 1] = (byte)((val % 100) / 10);
            this.Memory[this.RegisterI + 2] = (byte)((val % 100) % 10);
        }

        private void StoreV0ToVx(Instruction instruction)
        {
            for (int i = 0; i <= instruction.X; i++)
            {
                this.Memory[this.RegisterI + i] = (byte)this.RegisterV[i];
            }
        }

        private void FillV0ToVxFromMemory(Instruction instruction)
        {
            for (int i = 0; i <= instruction.X; i++)
            {
                this.RegisterV[i] = this.Memory[this.RegisterI + i];
            }
        }
    }
}
