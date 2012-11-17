namespace Chip8.Net.Video.Settings
{
    using System.Drawing;

    public class Graphics
    {
        private Graphics()
        {
        }

        public Size WindowSize { get; private set; }
        public Size RenderSize { get; private set; }
        public int Pixel { get; private set; }

        public static Graphics Small()
        {
            return new Graphics
            {
                WindowSize = new Size(401, 233),
                RenderSize = new Size(384, 192),
                Pixel = 0x6
            };
        }

        public static Graphics Large()
        {
            return new Graphics
            {
                WindowSize = new Size(802, 466),
                RenderSize = new Size(768, 384),
                Pixel = 0xC
            };
        }
    }
}
