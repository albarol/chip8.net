namespace Chip8.Net
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Chip8.Net.Engine;

    public partial class DebuggerDialog : Form
    {
        private VirtualMachine vm;

        public DebuggerDialog(VirtualMachine vm)
        {
            this.InitializeComponent();
            this.vm = vm;
            this.InitializeMemory();
        }

        private void InitializeMemory()
        {
            this.dtgMemory.Columns.Add("position", "Position");
            this.dtgMemory.Columns.Add("value", "Value");
            for (int i = 0; i < this.vm.Processor.Memory.Size; i++)
            {
                this.dtgMemory.Rows.Add(i.ToString(), this.vm.Processor.Memory[i].ToString("X"));
            }
        }
    }
}
