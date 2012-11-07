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
        public void StepRun_CanJumpToAddress()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0x1219;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x0219);
        }

        [Test]
        public void StepRun_CanCallSubroutine()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0x204d;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x004d);
        }

        [Test]
        public void StepRun_CanSkipNextFunctionIfVXEqualsNN()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0060;
            this.processor.Memory[0x200] = 0x3160;
            this.processor.Memory[0x201] = 0x0b61;
            this.processor.Memory[0x202] = 0x1b22;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSkipNextFunctionIfVXNotEqualsNN()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.Memory[0x200] = 0x4160;
            this.processor.Memory[0x201] = 0x0b61;
            this.processor.Memory[0x202] = 0x1b22;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSkipNextFunctionIfVXEqualsVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.RegisterV[0x2] = 0x0010;
            this.processor.Memory[0x200] = 0x5120;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSetVxToNn()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.Memory[0x200] = 0x6122;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0022);
        }

        [Test]
        public void StepRun_CanAddNnToVx()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.Memory[0x200] = 0x7122;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0032);
        }

        [Test]
        public void StepRun_SetVxToVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.RegisterV[0x2] = 0x0020;
            this.processor.Memory[0x200] = 0x8120;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0020);
        }

        [Test]
        public void StepRun_SetVxToVxOrVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0030;
            this.processor.RegisterV[0x2] = 0x0021;
            this.processor.Memory[0x200] = 0x8121;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0031);
        }

        [Test]
        public void StepRun_SetVxToVxAndVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0030;
            this.processor.RegisterV[0x2] = 0x0021;
            this.processor.Memory[0x200] = 0x8122;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0020);
        }

        [Test]
        public void StepRun_SetVxToVxXorVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0020;
            this.processor.RegisterV[0x2] = 0x0021;
            this.processor.Memory[0x200] = 0x8123;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x0001);
        }

        [Test]
        public void StepRun_AddVyToVxWithCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xF0;
            this.processor.RegisterV[0x2] = 0xA0;
            this.processor.Memory[0x200] = 0x8124;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_AddVyToVxWithoutCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xF0;
            this.processor.RegisterV[0x2] = 0x0F;
            this.processor.Memory[0x200] = 0x8124;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_SubtractVyToVxWithCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xF0;
            this.processor.RegisterV[0x2] = 0xA0;
            this.processor.Memory[0x200] = 0x8125;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_SubtractVyToVxWithoutCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0F;
            this.processor.RegisterV[0x2] = 0xF;
            this.processor.Memory[0x200] = 0x8125;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_ShiftVxRightOneWithCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0F;
            this.processor.RegisterV[0x2] = 0x0F;
            this.processor.Memory[0x200] = 0x8126;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_ShiftVxRightOneWithoutCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xF0;
            this.processor.RegisterV[0x2] = 0xF0;
            this.processor.Memory[0x200] = 0x8126;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_SubtractVxToVyWithCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xA0;
            this.processor.RegisterV[0x2] = 0xF0;
            this.processor.Memory[0x200] = 0x8127;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_SubtractVxToVyWithoutCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xF0;
            this.processor.RegisterV[0x2] = 0xA0;
            this.processor.Memory[0x200] = 0x8127;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_ShiftVxLeftOneWithCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0xFF;
            this.processor.RegisterV[0x2] = 0x0F;
            this.processor.Memory[0x200] = 0x812E;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_ShiftVxLeftOneWithoutCarry()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x40;
            this.processor.RegisterV[0x2] = 0xF0;
            this.processor.Memory[0x200] = 0x812E;

            // Act: 
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0xF].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_CanSkipNextFunctionIfVXNotEqualsVy()
        {
            // Arrange:
            this.processor.RegisterV[0x1] = 0x0010;
            this.processor.RegisterV[0x2] = 0x0020;
            this.processor.Memory[0x200] = 0x9120;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSetRegisterIToAdressNnn()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0xA010;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterI.Should().Be.EqualTo(0x0010);
        }

        [Test]
        public void StepRun_CanJumpToNnnPlusV0()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xB010;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x0011);
        }

        [Test]
        public void StepRun_CanSetVxRandomNumberAndNn()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x00;
            this.processor.Memory[0x200] = 0xC011;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x0].Should().Not.Be.EqualTo(0x00);
        }

    }
}
