namespace Chip8.Net.Video.Settings
{
    using System.Drawing;
    using System.Windows.Forms;

    public class VideoRender : Gpu
    {
        private Form view;
        public VideoRender(Form view)
        {
            this.view = view;
        }
        
        public override void DrawFrame()
        {
            var g = this.view.CreateGraphics();
            var pen = new Pen(Color.Azure);
            for (int column = 0; column < Gpu.Height; column++)
            {
                for (int row = 0; row < Gpu.Width; row++)
                {
                    if (this.Gfx[row, column] == 1)
                    {
                        g.DrawRectangle(pen, row, column, 1, 1);
                    }
                }
            }
        }
    }
}
