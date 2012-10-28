namespace Chip8.Net.Core
{
    public class Processor
    {
        private Memory memory;
        private short programCounter;
        private byte[] registerV;

        public Processor()
        {
            this.memory = new Memory();
            this.programCounter = 0x200;
            this.registerV = new byte[16];
        }


    }
}
