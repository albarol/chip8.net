namespace Chip8.Net.Video.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class Loader
    {
        public static int[] LoadRom(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                IList<int> opcodes = new List<int>();
                
                for (int i = 0; i < stream.Length; i += 2)
                {
                    string first = stream.ReadByte().ToString("X");
                    string second = stream.ReadByte().ToString("X").PadLeft(2, '0');
                    int opcode = int.Parse(string.Format("{0}{1}", first, second), NumberStyles.HexNumber);
                    opcodes.Add(opcode);
                }
                return opcodes.ToArray();
            }
        }
    }
}
