namespace Chip8.Net
{
    using System.Collections.Generic;

    public class Keyboard
    {
        private int[] keys = new int[0x10];
        public int LastPressedKey { get; set; }
    }
}
