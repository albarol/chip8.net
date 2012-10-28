namespace Chip8.Net.Core
{
    public class Stack
    {
        private readonly short[] stack;
        private byte pointer;
        
        public Stack()
        {
            this.pointer = 0x0;
            this.stack = new short[0x10];
        }

        public void Push(short opcode)
        {
            this.stack[this.pointer] = opcode;
            ++this.pointer;
        }
    }
}
