namespace Chip8.Net.Test
{
    using Chip8.Net.Test.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class GpuFixture
    {
        private Processor processor;
        private Gpu gpu;

        [SetUp]
        public void SetUp()
        {
            this.gpu = new TestGpu();
            this.processor = new Processor(this.gpu);
        }
        
        [Test]
        public void Draw_CanDrawSpriteInGpu()
        {
            // Arrange:
            int[] sprite = new[] { 0x0, 0xF, 0x3, 0xA };
            int x = 0, y = 0;

            // Act:
            this.gpu.Draw(x, y, sprite);
            this.gpu.DrawFrame();
        }
    }
}
