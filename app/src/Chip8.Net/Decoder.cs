namespace Chip8.Net
{
    using System.Globalization;

    public class Decoder
    {
        public static Instruction DecodeOpcode(byte b, byte b2)
        {
            var decode = string.Format("{0}{1}", b.ToString("X"), b2.ToString("X").PadLeft(2, '0'));
            var opcode = int.Parse(decode, NumberStyles.HexNumber);
            switch (opcode & 0xF000)
            {
                case 0x0000:
                    return Decode0xxx(opcode);
                case 0x8000:
                    return Decode8xxx(opcode);
                case 0xE000:
                    return DecodeExxx(opcode);
                case 0xF000:
                    return DecodeFxxx(opcode);
                default:
                    return DecodeDefault(opcode);
            }
        }

        private static Instruction Decode0xxx(int opcode)
        {
            return new Instruction
            {
                Opcode = opcode & 0x00FF,
                Nn = 0,
                Nnn = 0,
                N = 0,
                X = 0,
                Y = 0,
                Routine = opcode.ToString("X")
            };
        }

        private static Instruction Decode8xxx(int opcode)
        {
            return new Instruction
            {
                Opcode = opcode & 0xF00F,
                Nn = 0,
                Nnn = 0,
                N = 0,
                X = (opcode & 0x0F00) >> 8,
                Y = (opcode & 0x00F0) >> 4,
                Routine = opcode.ToString("X")
            };
        }

        private static Instruction DecodeExxx(int opcode)
        {
            return new Instruction
            {
                Opcode = opcode & 0xF0FF,
                Nn = 0,
                Nnn = 0,
                N = 0,
                X = (opcode & 0x0F00) >> 8,
                Y = 0,
                Routine = opcode.ToString("X")
            };
        }

        private static Instruction DecodeFxxx(int opcode)
        {
            return new Instruction
            {
                Opcode = opcode & 0xF0FF,
                Nn = 0,
                Nnn = 0,
                N = 0,
                X = (opcode & 0x0F00) >> 8,
                Y = 0,
                Routine = opcode.ToString("X")
            };
        }

        private static Instruction DecodeDefault(int opcode)
        {
            return new Instruction
            {
                Opcode = opcode & 0xF000,
                Nn = opcode & 0x00FF,
                Nnn = opcode & 0x0FFF,
                N = opcode & 0x000F,
                X = (opcode & 0x0F00) >> 8,
                Y = (opcode & 0x00F0) >> 4,
                Routine = opcode.ToString("X")
            };
        }
    }
}
