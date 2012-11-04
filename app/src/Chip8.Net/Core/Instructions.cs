namespace Chip8.Net.Core
{
    public class Instructions
    {
        public const int ClearScreen = 0x00E0;
        public const int ReturnRoutine = 0x00EE;
        public const int JumpTo = 0x1000;
        public const int CallRoutine = 0x2000;
        public const int SkipNextRegisterVxEqualAddress = 0x3000;
        public const int SkipNextRegisterVxNotEqualAddress = 0x4000;
        public const int SkipNextRegisterVxNotEqualVy = 0x5000;
        public const int SetVxToNn = 0x6000;
        public const int AddNnToVx = 0x7000;
        public const int SetVxToVy = 0x8000;
        public const int SetVxToVxOrVy = 0x8001;
    }
}
