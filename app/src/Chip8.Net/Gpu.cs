namespace Chip8.Net
{
    using System;

    public class Gpu
    {
        private const int Width = 64;
        private const int Height = 32;
        private readonly int[,] gfx = new int[Width, Height];

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
                        if (positionX + pixel >= Width || positionY + i >= Height)
                        {
                            break;
                        }

                        if (this.gfx[positionX + pixel, positionY + i] == 0x1)
                        {
                            carry = 0x1;
                        }

                        this.gfx[positionX + pixel, positionY + i] ^= 0x1;
                    }
                }
            }

            return carry;
        }

        private char[] TransformBitCodedToString(int value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0').ToCharArray();
        }

        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this.gfx[x, y] = 0x0;
                }
            }
        }
    }
}
