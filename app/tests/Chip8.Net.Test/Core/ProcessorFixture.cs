namespace Chip8.Net.Test.Core
{
    using System;

    using Chip8.Net.Core;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class ProcessorFixture
    {
        private Processor processor;

        [SetUp]
        public void SetUp()
        {
            this.processor = new Processor();
        }
        
        [Test]
        public void CanJumpToAddress()
        {
            // Arrange:
            short opcode = 0x1219;

            // Act:
            this.processor.InterpretOpcode(opcode);

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x0219);
        }

        [Test]
        public void CanCallSubroutine()
        {
            // Arrange:
            short opcode = 0x204d;

            // Act:
            this.processor.InterpretOpcode(opcode);

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x004d);
        }

        [Test]
        public void CanSkipNextFunctionIfVXEqualsNN()
        {
            // Arrange:
            short opcode = 0x3160;

            // Act:
            this.processor.InterpretOpcode(opcode);

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(1);
        }
    }
}
