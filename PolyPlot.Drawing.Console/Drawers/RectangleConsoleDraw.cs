using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class RectangleConsoleDrawable : IDrawable
{
    private readonly IConsoleOutput _consoleOutput;
    public RectangleConsoleDrawable(IConsoleOutput consoleOutput) => _consoleOutput = consoleOutput;
    public void Draw(Widget widget)
    {
        var rectangle = (Rectangle)widget;
        _consoleOutput.WriteLine($"Rectangle {rectangle.Position} width={rectangle.Width} height={rectangle.Height}");
    }

    public bool CanDraw(Widget widget) => widget.GetType().FullName == typeof(Rectangle).FullName;
}