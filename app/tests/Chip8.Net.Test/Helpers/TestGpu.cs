namespace Chip8.Net.Test.Helpers
{
    using System;

    using Chip8.Net.Engine;

    public class TestGpu : Gpu
    {
        public override void DrawFrame()
        {
            for (int column = 0; column < Gpu.Height; column++)
            {
                for (int row = 0; row < Gpu.Width; row++)
                {
                    if (this.Gfx[row, column] == 0x0)
                    {
                        Console.WriteLine("*".PadLeft(column, ' '));
                    }
                    else
                    {
                        Console.WriteLine("#".PadLeft(column, ' '));
                    }
                }
            }
        }
    }
}
