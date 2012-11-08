namespace Chip8.Net
{
    using System.Collections.Generic;

    public class Character
    {
        private static IDictionary<int, int> characters = new Dictionary<int, int>
        {
            { 0x0, 0x30 },
            { 0x1, 0x31 },
            { 0x2, 0x32 },
            { 0x3, 0x33 },
            { 0x4, 0x34 },
            { 0x5, 0x35 },
            { 0x6, 0x36 },
            { 0x7, 0x37 },
            { 0x8, 0x38 },
            { 0x9, 0x39 },
            { 0xA, 0x41 },
            { 0xB, 0x42 },
            { 0xC, 0x43 },
            { 0xD, 0x44 },
            { 0xE, 0x45 },
            { 0xF, 0x46 }
        };

        public static int GetCharacter(int place)
        {
            int character = characters[0x0];
            
            if (characters.ContainsKey(place))
            {
                character = characters[place];
            }

            return character;
        }
    }
}
