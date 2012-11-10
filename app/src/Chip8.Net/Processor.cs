namespace Chip8.Net
{
    using System;
    using System.Globalization;

    public class Processor
    {
        private int delayTimer;
        private int soundTimer;
        private int stack;
        
        public Processor(Gpu gpu)
        {
            this.delayTimer = 0x0;
            this.soundTimer = 0x0;
            this.stack = 0x0;
            this.Memory = new Memory();
            this.ProgramCounter = 0x200;
            this.RegisterV = new Register(0x10);
            this.Gpu = gpu;
            this.Keyboard = new Keyboard();
            this.RegisterI = 0x0;
        }

        public Memory Memory { get; private set; }
        public Register RegisterV { get; private set; }
        public int RegisterI { get; private set; }
        public Gpu Gpu { get; private set; }
        public Keyboard Keyboard { get; private set; }

        public int ProgramCounter { get; private set; }

        public void StepRun()
        {
            var decode = string.Format("{0}{1}", this.Memory[this.ProgramCounter].ToString("X"), this.Memory[this.ProgramCounter + 1].ToString("X").PadLeft(2, '0'));
            var opcode = int.Parse(decode, NumberStyles.HexNumber);
            this.InterpretOpcode(opcode);
            this.ProgramCounter += 2;
        }

        private void InterpretOpcode(int opcode)
        {
            if (opcode == Opcodes.ClearScreen)
            {
                Gpu.Clear();
            }
            else if (opcode == Opcodes.ReturnRoutine)
            {
                this.ProgramCounter = this.stack;
                this.stack = 0x0;
            }
            else if ((opcode & 0xF000) == Opcodes.JumpTo)
            {
                this.JumpTo(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.CallRoutine)
            {
                this.CallRoutine(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SkipNextRegisterVxEqualAddress)
            {
                this.SkipNextRegisterVxEqualAddress(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SkipNextRegisterVxNotEqualAddress)
            {
                this.SkipNextRegisterVxNotEqualAddress(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SkipNextRegisterVxEqualVy)
            {
                this.SkipNextRegisterVxEqualVy(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SetVxToNn)
            {
                this.SetVxToNn(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.AddNnToVx)
            {
                this.AddNnToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToVy)
            {
                this.SetVxToVy(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToVxOrVy)
            {
                this.SetVxToVxOrVy(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToVxAndVy)
            {
                this.SetVxToVxAndVy(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToVxXorVy)
            {
                this.SetVxToVxXorVy(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.AddVyToVx)
            {
                this.AddVyToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SubtractVyFromVx)
            {
                this.SubtractVyToVx(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.ShiftVxRightByOne)
            {
                this.ShiftVxRightByOne(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToVyMinusVx)
            {
                this.SetVxToVyMinusVx(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.ShiftVxLeftByOne)
            {
                this.ShiftVxLeftByOne(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SkipNextRegisterVxNotEqualVy)
            {
                this.SkipNextRegisterVxNotEqualVy(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SetIToAddressNnn)
            {
                this.SetIToAddressNnn(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.JumpToPlusV0)
            {
                this.JumpToPlusV0(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.SetVxRandomNumberAndNn)
            {
                this.SetVxRandomNumberAndNn(opcode);
            }
            else if ((opcode & 0xF000) == Opcodes.DrawSprite)
            {
                this.DrawSprite(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.SkipIfKeyInVxPressed)
            {
                this.SkipIfKeyInVxPressed(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.SkipIfKeyInVxNotPressed)
            {
                this.SkipIfKeyInVxNotPressed(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.SetVxToDelayTimer)
            {
                this.SetVxToDelayTimer(opcode);
            }
            else if ((opcode & 0xF00F) == Opcodes.StoreWaitingKeyInVx)
            {
                this.StoreWaitingKeyInVx(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.SetDelayTimerToVx)
            {
                this.SetDelayTimerToVx(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.SetSoundTimerToVx)
            {
                this.SetSoundTimerToVx(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.AddVxToI)
            {
                this.AddVxToI(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.SetIToCharacterVx)
            {
                this.SetIToCharacterVx(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.StoreInVxDecimalRegisterI)
            {
                this.StoreInVxDecimalRegisterI(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.StoreV0ToVx)
            {
                this.StoreV0ToVx(opcode);
            }
            else if ((opcode & 0xF0FF) == Opcodes.FillV0ToVxFromMemory)
            {
                this.FillV0ToVxFromMemory(opcode);
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
            this.stack = this.ProgramCounter;
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

        private void JumpToPlusV0(int opcode)
        {
            int place = opcode & 0x0FFF;
            this.ProgramCounter = place + this.RegisterV[0x0];
        }

        private void SetVxRandomNumberAndNn(int opcode)
        {
            var rnd = new Random();
            int positionX = (opcode & 0x0F00) >> 8;
            int place = opcode & 0x00FF;
            this.RegisterV[positionX] = rnd.Next(0x100) & place;
        }

        private void DrawSprite(int opcode)
        {
            const int Carry = 0xF;
            int positionX = (opcode & 0x0F00) >> 8;
            int positionY = (opcode & 0x00F0) >> 4;
            int size = opcode & 0x000F;

            int[] sprite = new int[size];
            int count = 0;
            for (int index = this.RegisterI; index < (this.RegisterI + size); index++)
            {
                sprite[count++] = this.Memory[index];
            }
            this.RegisterV[Carry] = this.Gpu.Draw(this.RegisterV[positionX], this.RegisterV[positionY], sprite);
            this.Gpu.DrawFrame();
        }

        private void SkipIfKeyInVxPressed(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            if (this.RegisterV[positionX] == Keyboard.LastPressedKey)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SkipIfKeyInVxNotPressed(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            if (this.RegisterV[positionX] != Keyboard.LastPressedKey)
            {
                this.ProgramCounter += 0x2;
            }
        }

        private void SetVxToDelayTimer(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            this.delayTimer = this.RegisterV[positionX];
        }

        private void StoreWaitingKeyInVx(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            while (Keyboard.WaitingKey())
            {
            }
            this.RegisterV[positionX] = this.Keyboard.LastPressedKey;
        }

        private void SetDelayTimerToVx(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            this.RegisterV[positionX] = this.delayTimer;
        }

        private void SetSoundTimerToVx(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            this.RegisterV[positionX] = this.soundTimer;
        }

        private void AddVxToI(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            this.RegisterI += this.RegisterV[positionX];
            this.RegisterV[0xF] = (this.RegisterI > 0xFFF) ? 0x1 : 0x0;
            this.RegisterI = this.RegisterI & 0xFFF;
        }
        
        private void SetIToCharacterVx(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            this.RegisterI = Character.GetCharacter(this.RegisterV[positionX]);
        }

        private void StoreInVxDecimalRegisterI(int opcode)
        {
            int positionX = (opcode & 0x0FFF) >> 8;
            string representation = (this.RegisterV[positionX] & 0xFFF).ToString("D3");
            
            this.Memory[this.RegisterI] = Convert.ToInt32(representation[0].ToString());
            this.Memory[this.RegisterI + 1] = Convert.ToInt32(representation[1].ToString());
            this.Memory[this.RegisterI + 2] = Convert.ToInt32(representation[2].ToString());
        }

        private void StoreV0ToVx(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            for (int i = 0; i <= positionX; i++)
            {
                this.Memory[this.RegisterI + i] = this.RegisterV[i];
            }
        }

        private void FillV0ToVxFromMemory(int opcode)
        {
            int positionX = (opcode & 0x0F00) >> 8;
            for (int i = 0; i <= positionX; i++)
            {
                this.RegisterV[i] = this.Memory[this.RegisterI + i];
            }
        }
    }
}
