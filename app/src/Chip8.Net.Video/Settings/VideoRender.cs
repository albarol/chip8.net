namespace Chip8.Net.Video.Settings
{
    using System.Drawing;
    using System.Windows.Forms;

    public class VideoRender : Gpu
    {
        private const int Size = 0x6;
        private readonly Form view;
        private readonly Pen foreground;
        private readonly Pen background;

        public VideoRender(Form view)
        {
            this.view = view;
            this.foreground = new Pen(Color.Azure);
            this.background = new Pen(Color.Black);
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
                        g.DrawRectangle(this.background, row * Size, column * Size, Size, Size);
                    }
                    else
                    {
                        g.DrawRectangle(this.foreground, row * Size, column * Size, Size, Size);
                    }
                }
            }
        }
    }
}
