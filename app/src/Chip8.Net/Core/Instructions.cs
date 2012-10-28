namespace Chip8.Net.Core
{
    public class Instructions
    {
        public const short ClearScreen = 0x00E0;
        public const short ReturnRoutine = 0x00EE;
        public const short JumpTo = 0x1000;
        public const short CallRoutine = 0x2000;
        public const short SkipNextRegisterEqualAddress = 0x4000;
    }
}
