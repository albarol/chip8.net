namespace Chip8.Net.Settings
{
    using System.Drawing;
    using System.Windows.Forms;

    using Chip8.Net.Engine;

    public class VideoRender : Gpu
    {
        private readonly PictureBox view;
        private readonly Brush foreground;
        private readonly Brush background;

        public VideoRender(PictureBox view)
        {
            this.view = view;
            this.foreground = new SolidBrush(Color.White);
            this.background = new SolidBrush(Color.Black);
        }

        public int PixelSize
        {
            get
            {
                if (this.view.Size.Width == 768)
                {
                    return 0xC;
                }
                return 0x6;
            }
        }
        
        public override void DrawFrame()
        {
            var g = this.view.CreateGraphics();
            
            for (int column = 0; column < Gpu.Height; column++)
            {
                for (int row = 0; row < Gpu.Width; row++)
                {
                    if (this.Gfx[row, column] == 0x0)
                    {
                        g.FillRectangle(this.background, row * this.PixelSize, column * this.PixelSize, this.PixelSize, this.PixelSize);
                    }
                    else
                    {
                        g.FillRectangle(this.foreground, row * this.PixelSize, column * this.PixelSize, this.PixelSize, this.PixelSize);
                    }
                }
            }
        }
    }
}
