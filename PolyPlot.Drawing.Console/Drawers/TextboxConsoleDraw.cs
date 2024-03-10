using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class TextboxConsoleDrawable : IDrawable
{
    public IRenderOutput Draw(Widget widget)
    {
        var textbox = (Textbox)widget;
        return new ConsoleRenderOutput($"Textbox {textbox.Position} width={textbox.Width} height={textbox.Height} text=\"{textbox.Text}\"");
    }

    public bool CanDraw(Widget widget) => widget is Textbox;
}