namespace Chip8.Net.Test
{
    using System;

    using Chip8.Net.Engine;
    using Chip8.Net.Test.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class MemoryFixture
    {
        private Processor processor;

        [SetUp]
        public void SetUp()
        {
            this.processor = new Processor(new TestGpu());
        }
        
        [Test]
        public void CanAccessValidPositionInMemory()
        {
            // Arrange:
            const int Position = 0x219;
            this.processor.Memory[Position] = 0x000;
            
            // Act:
            var item = this.processor.Memory[Position];

            // Assert:
            item.Should().Be.EqualTo((byte)0x000);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTryAccessInvalidPosition()
        {
            // Arrange:
            const int Position = 0x000;
            
            // Act
            var item = this.processor.Memory[Position];
        }
    }
}
