namespace Chip8.Net.Engine
{
    public class Opcodes
    {
        public const int CLS = 0x00E0;
        public const int RET = 0x00EE;
        public const int JP = 0x1000;
        public const int CALL = 0x2000;
        public const int SE = 0x3000;
        public const int SNE = 0x4000;
        public const int SER = 0x5000;
        public const int SETB = 0x6000;
        public const int ADD = 0x7000;
        public const int SET = 0x8000;
        public const int OR = 0x8001;
        public const int AND = 0x8002;
        public const int XOR = 0x8003;
        public const int ADDR = 0x8004;
        public const int SUB = 0x8005;
        public const int SHR = 0x8006;
        public const int SUBN = 0x8007;
        public const int SHL = 0x800E;
        public const int SNER = 0x9000;
        public const int SETI = 0xA000;
        public const int JPR = 0xB000;
        public const int RND = 0xC000;
        public const int DRW = 0xD000;
        public const int SKP = 0xE09E;
        public const int SKPN = 0xE0A1;
        public const int DT = 0xF007;
        public const int KEY = 0xF00A;
        public const int DTR = 0xF015;
        public const int ST = 0xF018;
        public const int ADDI = 0xF01E;
        public const int LDI = 0xF029;
        public const int LDB = 0xF033;
        public const int STR = 0xF055;
        public const int FILL = 0xF065;
    }
}
