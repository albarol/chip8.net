namespace Chip8.Net.Video.View
{
    using System.Drawing;

    public interface IRenderDialog
    {
        Size RenderSize { get; set; }
        Size WindowSize { get; set; }   
    }
}
