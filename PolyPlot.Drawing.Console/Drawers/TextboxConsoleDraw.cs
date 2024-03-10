using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class TextboxConsoleDrawable : IDrawable
{
    private readonly IConsoleOutput _consoleOutput;
    public TextboxConsoleDrawable(IConsoleOutput consoleOutput) => _consoleOutput = consoleOutput;
    public void Draw(Widget widget)
    {
        var textbox = (Textbox)widget;
        _consoleOutput.WriteLine($"Textbox {textbox.Position} width={textbox.Width} height={textbox.Height} text=\"{textbox.Text}\"");
    }

    public bool CanDraw(Widget widget) => widget is Textbox;
}