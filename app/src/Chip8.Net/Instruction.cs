namespace Chip8.Net
{
    public class Instruction
    {
        public int Nnn { get; set; }
        public int Nn { get; set; }
        public int N { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Opcode { get; set; }
        public string Routine { get; set; }
    }
}
