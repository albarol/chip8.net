namespace Chip8.Net.Settings
{
    using System.Drawing;

    public class Graphics
    {
        private Graphics()
        {
        }

        public Size WindowSize { get; private set; }
        public Size RenderSize { get; private set; }
        
        public static Graphics Small()
        {
            return new Graphics
            {
                WindowSize = new Size(408, 272),
                RenderSize = new Size(384, 192)
            };
        }

        public static Graphics Large()
        {
            return new Graphics
            {
                WindowSize = new Size(806, 474),
                RenderSize = new Size(768, 384)
            };
        }
    }
}
