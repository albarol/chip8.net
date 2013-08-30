namespace Chip8.Net.Settings
{
    using System.Drawing;
    using System.Windows.Forms;

    using Chip8.Net.Engine;

    public class VideoRender : Gpu
    {
        private readonly PictureBox view;
		BufferedGraphicsContext bufferContext;
		BufferedGraphics buffer;
        private readonly Brush foreground;
        private readonly Brush background;

        public VideoRender(PictureBox view)
        {
            this.view = view;
			this.bufferContext = BufferedGraphicsManager.Current;
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
            this.buffer = bufferContext.Allocate(this.view.CreateGraphics(), this.view.DisplayRectangle);
			for (int column = 0; column < Gpu.Height; column++)
            {
                for (int row = 0; row < Gpu.Width; row++)
                {
					Brush currentBrush = (this.Gfx[row, column] == 0x0) ? background : foreground;
					this.buffer.Graphics.FillRectangle(currentBrush, row * this.PixelSize, column * this.PixelSize, this.PixelSize, this.PixelSize);
                }
            }
			this.buffer.Render();
        }
    }
}
