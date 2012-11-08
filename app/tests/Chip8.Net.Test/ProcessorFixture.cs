namespace Chip8.Net.Test
{
    using Chip8.Net.Test.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class ProcessorFixture
    {
        private Processor processor;

        [SetUp]
        public void SetUp()
        {
            this.processor = new Processor(new TestGpu());
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

        [Test]
        public void StepRun_CanSkipWhenLastPressedKeyIsEqualVx()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xE09E;
            this.processor.Keyboard.PressKey(0x50);

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSkipWhenLastPressedKeyIsNotEqualVx()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xE0A1;
            this.processor.Keyboard.PressKey(0x41);

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.ProgramCounter.Should().Be.EqualTo(0x202);
        }

        [Test]
        public void StepRun_CanSetDelayTimerToVx()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xF015;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x0].Should().Be.EqualTo(0x0);
        }

        [Test]
        public void StepRun_CanStoreWaitingKeyInVx()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xF00A;
            this.processor.Keyboard.PressKey(0x52);

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x0].Should().Be.EqualTo(0x3);
        }

        [Test]
        public void StepRun_CanAddVxToI()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xF01E;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterI.Should().Be.EqualTo(0x1);
        }

        [Test]
        public void StepRun_CanSetILocationToVx()
        {
            // Arrange:
            this.processor.RegisterV[0x0] = 0x01;
            this.processor.Memory[0x200] = 0xF029;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterI.Should().Be.EqualTo(0x31);
        }

        [Test]
        public void StepRun_CanStoreInVxDecimalRegisterI()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0xA001;
            this.processor.Memory[0x201] = 0xF033;
            this.processor.RegisterV[0x0] = 0x20;
            this.processor.StepRun();

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.Memory[0x2].Should().Be.EqualTo(0x03);
            this.processor.Memory[0x3].Should().Be.EqualTo(0x02);
        }

        [Test]
        public void StepRun_CanStoreV0ToVx()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0xA001;
            this.processor.StepRun();

            this.processor.RegisterV[0x0] = 0x01;
            this.processor.RegisterV[0x1] = 0x02;
            this.processor.RegisterV[0x2] = 0x03;
            this.processor.RegisterV[0x3] = 0x04;
            this.processor.RegisterV[0x4] = 0x05;
            this.processor.Memory[0x201] = 0xF455;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x01);
            this.processor.RegisterV[0x2].Should().Be.EqualTo(0x01);
        }

        [Test]
        public void StepRun_CanFillV0ToVx()
        {
            // Arrange:
            this.processor.Memory[0x200] = 0xA002;
            this.processor.StepRun();

            this.processor.RegisterV[0x0] = 0x01;
            this.processor.RegisterV[0x1] = 0x02;
            this.processor.RegisterV[0x2] = 0x03;
            this.processor.RegisterV[0x3] = 0x04;
            this.processor.RegisterV[0x4] = 0x05;
            this.processor.Memory[0x201] = 0xF465;

            // Act:
            this.processor.StepRun();

            // Assert:
            this.processor.RegisterV[0x0].Should().Be.EqualTo(0x03);
            this.processor.RegisterV[0x1].Should().Be.EqualTo(0x04);
        }
    }
}
