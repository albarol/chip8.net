namespace Chip8.Net
{
    using System.Collections.Generic;

    public class Keyboard
    {
        private int releaseKey = 0xFF;
        private IDictionary<int, int> keys = new Dictionary<int, int>
        {
            { 0x49, 0x0 },
            { 0x50, 0x1 },
            { 0x51, 0x2 },
            { 0x52, 0x3 },
            { 0x81, 0x4 },
            { 0x87, 0x5 },
            { 0x69, 0x6 },
            { 0x82, 0x7 },
            { 0x65, 0x8 },
            { 0x83, 0x9 },
            { 0x68, 0xA },
            { 0x70, 0xB },
            { 0x90, 0xC },
            { 0x88, 0xD },
            { 0x67, 0xE },
            { 0x86, 0xF }
        };

        private int pressedKey;
        
        public int LastPressedKey
        {
            get
            {
                return this.pressedKey;
            }
        }

        public void PressKey(int key)
        {
            if (this.keys.ContainsKey(key))
            {
                this.pressedKey = this.keys[key];
            }
        }

        public void ReleaseKey()
        {
            this.pressedKey = this.releaseKey;
        }
        
        public bool WaitingForKey()
        {
            return this.LastPressedKey != this.releaseKey;
        }
    }
}
