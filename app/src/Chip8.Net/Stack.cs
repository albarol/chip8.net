namespace Chip8.Net
{
    public class Stack
    {
        private readonly int[] stack;
        private byte pointer;
        
        public Stack()
        {
            this.pointer = 0x0;
            this.stack = new int[0x10];
        }

        public void Push(int opcode)
        {
            this.stack[this.pointer] = opcode;
            ++this.pointer;
        }
    }
}
