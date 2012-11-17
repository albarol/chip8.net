namespace Chip8.Net
{
    using System.Collections.Generic;

    public class Keyboard
    {
        private byte[] keyboard = new byte[16];
        private IDictionary<int, int> keyboardMap = new Dictionary<int, int>
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

        public int LastPressedKey { get; private set; }

        public void PressKey(int key)
        {
            if (this.keyboardMap.ContainsKey(key))
            {
                this.keyboard[this.keyboardMap[key]] = 0x1;
                this.LastPressedKey = this.keyboardMap[key];
            }
        }

        public void ReleaseKey(int key)
        {
            if (this.keyboardMap.ContainsKey(key))
            {
                this.keyboard[this.keyboardMap[key]] = 0x0;
                this.LastPressedKey = -1;
            }
        }
        
        public int WaitingForKey()
        {
            int keyPressed = -1;

            for (int i = 0; i < 16; ++i)
            {
                if (this.keyboard[i] != 0x0)
                {
                    keyPressed = i;
                }
            }
            return keyPressed;
        }
    }
}
