namespace Chip8.Net.View
{
    using System.Drawing;

    public interface IRenderDialog
    {
        Size RenderSize { get; set; }
        Size WindowSize { get; set; }
    }
}
