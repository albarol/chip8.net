namespace Chip8.Net.Video.Settings
{
    using System.Drawing;
    using System.Windows.Forms;

    public class VideoRender : Gpu
    {
        private readonly int pixelSize = 0x6;
        private readonly PictureBox view;
        private readonly Brush foreground;
        private readonly Brush background;

        public VideoRender(PictureBox view, int pixelSize)
        {
            this.view = view;
            this.pixelSize = pixelSize;
            this.foreground = new SolidBrush(Color.White);
            this.background = new SolidBrush(Color.Black);
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
                        g.FillRectangle(this.background, row * this.pixelSize, column * this.pixelSize, this.pixelSize, this.pixelSize);
                    }
                    else
                    {
                        g.FillRectangle(this.foreground, row * this.pixelSize, column * this.pixelSize, this.pixelSize, this.pixelSize);
                    }
                }
            }
        }
    }
}
