namespace Chip8.Net.Video.Settings
{
    using System.IO;

    public class Loader
    {
        public static int[] LoadRom(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                int[] rom = new int[stream.Length];
                
                for (int i = 0; i < stream.Length; i++)
                {
                    rom[i] = stream.ReadByte();
                }
                return rom;
            }
        }
    }
}
