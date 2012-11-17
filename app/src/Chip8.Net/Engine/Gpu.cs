namespace Chip8.Net.Engine
{
    using System;

    public abstract class Gpu
    {
        protected const int Width = 64;
        protected const int Height = 32;
        protected readonly int[,] Gfx = new int[Width, Height];

        public int Draw(int x, int y, int[] sprite)
        {
            int positionY = y;
            int positionX = x;
            int carry = 0x0;

            for (int i = 0; i < sprite.Length; i++)
            {
                char[] line = this.TransformBitCodedToString(sprite[i]);
                
                for (int pixel = 0; pixel < 8; pixel++)
                {
                    if (line[pixel] == '1')
                    {
                        if (positionX + pixel < Width && positionY + i < Height)
                        {
                            if (this.Gfx[positionX + pixel, positionY + i] == 0x1)
                            {
                                carry = 0x1;
                            }

                            this.Gfx[positionX + pixel, positionY + i] ^= 0x1;
                        }
                    }
                }
            }

            return carry;
        }

        public abstract void DrawFrame();

        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this.Gfx[x, y] = 0x0;
                }
            }
        }

        private char[] TransformBitCodedToString(int value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0').ToCharArray();
        }
    }
}
