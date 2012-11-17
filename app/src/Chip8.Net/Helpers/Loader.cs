namespace Chip8.Net.Helpers
{
    using System.IO;

    public class Loader
    {
        public static byte[] LoadRom(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
