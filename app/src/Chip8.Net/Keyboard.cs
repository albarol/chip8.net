namespace Chip8.Net
{
    public class Keyboard
    {
        private int[] keys = new int[0x10];
        public int LastPressedKey { get; set; }
    }
}
