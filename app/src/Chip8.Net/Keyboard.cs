namespace Chip8.Net
{
    using System.Collections.Generic;

    public class Keyboard
    {
        private int releaseKey = 0xFF;
        private IDictionary<int, int> keys = new Dictionary<int, int>
        {
            { 49, 0x0 },
            { 50, 0x1 },
            { 51, 0x2 },
            { 52, 0x3 },
            { 81, 0x4 },
            { 87, 0x5 },
            { 69, 0x6 },
            { 82, 0x7 },
            { 65, 0x8 },
            { 83, 0x9 },
            { 68, 0xA },
            { 70, 0xB },
            { 90, 0xC },
            { 88, 0xD },
            { 67, 0xE },
            { 86, 0xF }
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
        
        public bool WaitingKey()
        {
            return this.LastPressedKey == this.releaseKey;
        }
    }
}
