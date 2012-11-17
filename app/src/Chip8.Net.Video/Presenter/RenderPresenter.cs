namespace Chip8.Net.Video.Presenter
{
    using Chip8.Net.Video.Settings;
    using Chip8.Net.Video.View;

    using Graphics = Chip8.Net.Video.Settings.Graphics;

    public class RenderPresenter
    {
        private readonly IRenderDialog view;
        private readonly VirtualMachine virtualMachine;

        public RenderPresenter(IRenderDialog view, VirtualMachine virtualMachine)
        {
            this.view = view;
            this.virtualMachine = virtualMachine;
            this.SetGraphics(Graphics.Small());
        }

        public void SetGraphics(Graphics graphics)
        {
            this.view.RenderSize = graphics.RenderSize;
            this.view.WindowSize = graphics.WindowSize;
        }

        public void InitializeRom(string loadedRom)
        {
            this.virtualMachine.Stop();
            this.virtualMachine.LoadRom(loadedRom);
            this.virtualMachine.Run();
        }
    }
}
