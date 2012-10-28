namespace Chip8.Net.Test.Core
{
    using Chip8.Net.Core;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class MemoryFixture
    {
        private Memory memory;

        [SetUp]
        public void SetUp()
        {
            this.memory = new Memory();
        }
        
        [Test]
        public void CanAccessValidPositionInMemory()
        {
            // Arrange:
            const int Position = 0x219;
            this.memory[Position] = 0x000;
            
            // Act:
            var item = this.memory[Position];

            // Assert:
            item.Should().Be.EqualTo((byte)0x000);
        }
    }
}
