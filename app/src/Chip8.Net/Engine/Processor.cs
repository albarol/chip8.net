namespace Chip8.Net.Engine
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

        private void InterpretOpcode (Instruction instruction)
		{
			switch (instruction.Opcode) {
			case Opcodes.CLS:
				this.Gpu.Clear ();
				break;
			case Opcodes.RET:
				this.ReturnRoutine ();
				break;
			case Opcodes.JP:
				this.JumpTo (instruction);
				break;
			case Opcodes.CALL:
				this.CallRoutine (instruction);
				break;
			case Opcodes.SE:
				this.SkipNextRegisterVxEqualAddress (instruction);
				break;
			case Opcodes.SNE:
				SkipNextRegisterVxNotEqualAddress (instruction);
				break;
			case Opcodes.SER:
				SkipNextRegisterVxEqualVy (instruction);
				break;
			case Opcodes.SETB:
				SetVxToNn (instruction);
				break;
			case Opcodes.ADD:
				AddNnToVx (instruction);
				break;
			case Opcodes.SET:
				SetVxToVy (instruction);
				break;
			case Opcodes.OR:
				SetVxToVxOrVy (instruction);
				break;
			case Opcodes.AND:
				SetVxToVxAndVy (instruction);
				break;
			case Opcodes.XOR:
				SetVxToVxXorVy (instruction);
				break;
			case Opcodes.ADDR:
				AddVyToVx (instruction);
				break;
			case Opcodes.SUB:
				SubtractVyToVx (instruction);
				break;
			case Opcodes.SHR:
				ShiftVxRightByOne (instruction);
				break;
			case Opcodes.SUBN:
				SetVxToVyMinusVx (instruction);
				break;
			case Opcodes.SHL:
				ShiftVxLeftByOne (instruction);
				break;
			case Opcodes.SNER:
				SkipNextRegisterVxNotEqualVy (instruction);
				break;
			case Opcodes.SETI:
				SetIToAddressNnn (instruction);
				break;
			case Opcodes.JPR:
				JumpToPlusV0 (instruction);
				break;
			case Opcodes.RND:
				SetVxRandomNumberAndNn (instruction);
				break;
			case Opcodes.DRW:
				DrawSprite (instruction);
				break;
			case Opcodes.SKP:
				SkipIfKeyInVxPressed (instruction);
				break;
			case Opcodes.SKPN:
				SkipIfKeyInVxNotPressed (instruction);
				break;
			case Opcodes.DT:
				SetVxToDelayTimer (instruction);
				break;
			case Opcodes.KEY:
				StoreWaitingKeyInVx (instruction);
				break;
			case Opcodes.DTR:
				SetDelayTimerToVx (instruction);
				break;
			case Opcodes.ST:
				SetSoundTimerToVx (instruction);
				break;
			case Opcodes.ADDI:
				AddVxToI (instruction);
				break;
			case Opcodes.LDI:
				SetIToCharacterVx (instruction);
				break;
			case Opcodes.LDB:
				StoreInVxDecimalRegisterI (instruction);
				break;
			case Opcodes.STR:
				StoreV0ToVx (instruction);
				break;
			case Opcodes.FILL:
				FillV0ToVxFromMemory (instruction);
				break;
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
            this.RegisterV[Carry] = this.Gpu.Draw(this.RegisterV[instruction.X], this.RegisterV[instruction.Y], sprite);
            this.Gpu.DrawFrame();
        }

        private void SkipIfKeyInVxPressed(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] == this.Keyboard.LastPressedKey)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipIfKeyInVxNotPressed(Instruction instruction)
        {
            if (this.RegisterV[instruction.X] != this.Keyboard.LastPressedKey)
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
                this.RegisterI = (ushort)this.Memory.Size;
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
