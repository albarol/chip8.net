namespace Chip8.Net
{
    public class Instructions
    {
        public const int ClearScreen = 0x00E0;
        public const int ReturnRoutine = 0x00EE;
        public const int JumpTo = 0x1000;
        public const int CallRoutine = 0x2000;
        public const int SkipNextRegisterVxEqualAddress = 0x3000;
        public const int SkipNextRegisterVxNotEqualAddress = 0x4000;
        public const int SkipNextRegisterVxEqualVy = 0x5000;
        public const int SetVxToNn = 0x6000;
        public const int AddNnToVx = 0x7000;
        public const int SetVxToVy = 0x8000;
        public const int SetVxToVxOrVy = 0x8001;
        public const int SetVxToVxAndVy = 0x8002;
        public const int SetVxToVxXorVy = 0x8003;
        public const int AddVyToVx = 0x8004;
        public const int SubtractVyFromVx = 0x8005;
        public const int ShiftVxRightByOne = 0x8006;
        public const int SetVxToVyMinusVx = 0x8007;
        public const int ShiftVxLeftByOne = 0x800E;
        public const int SkipNextRegisterVxNotEqualVy = 0x9000;
        public const int SetIToAddressNnn = 0xA000;
        public const int JumpToPlusV0 = 0xB000;
        public const int SetVxRandomNumberAndNn = 0xC000;
        public const int DrawSprite = 0xD000;
        public const int SkipIfKeyInVxPressed = 0xE09E;
        public const int SkipIfKeyInVxNotPressed = 0xE0A1;
        public const int SetVxToDelayTimer = 0xF007;
        public const int StoreWaitingKeyInVx = 0xF00A;
        public const int SetDelayTimerToVx = 0xF015;
        public const int SetSoundTimerToVx = 0xF018;
        public const int AddVxToI = 0xF01E;
        public const int SetIToCharacterVx = 0xF029;
        public const int StoreInVxDecimalRegisterI = 0xF033;
        public const int StoreV0ToVx = 0xF055;
        public const int FillV0ToVxFromMemory = 0xF065;
    }
}
