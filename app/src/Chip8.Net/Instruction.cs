namespace Chip8.Net
{
    public class Instruction
    {
        public int Nnn { get; private set; }
        public int Nn { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Opcode { get; private set; }
    }
}
