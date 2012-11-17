namespace Chip8.Net.Engine
{
    using System.Collections.Generic;

    public class Keyboard
    {
        private byte[] keyboard = new byte[16];
        private IDictionary<char, int> keyboardMap = new Dictionary<char, int>
        {
            { '1', 0x0 },
            { '2', 0x1 },
            { '3', 0x2 },
            { '4', 0x3 },
            { 'Q', 0x4 },
            { 'W', 0x5 },
            { 'E', 0x6 },
            { 'R', 0x7 },
            { 'A', 0x8 },
            { 'S', 0x9 },
            { 'D', 0xA },
            { 'F', 0xB },
            { 'Z', 0xC },
            { 'X', 0xD },
            { 'C', 0xE },
            { 'V', 0xF }
        };

        public int LastPressedKey { get; private set; }

        public void PressKey(char key)
        {
            if (this.keyboardMap.ContainsKey(key))
            {
                this.keyboard[this.keyboardMap[key]] = 0x1;
                this.LastPressedKey = this.keyboardMap[key];
            }
        }

        public void ReleaseKey(char key)
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
