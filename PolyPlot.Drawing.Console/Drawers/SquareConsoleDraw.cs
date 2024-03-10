using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class SquareConsoleDrawable : IDrawable
{
    private readonly IConsoleOutput _consoleOutput;
    public SquareConsoleDrawable(IConsoleOutput consoleOutput) => _consoleOutput = consoleOutput;
    public void Draw(Widget widget)
    {
        var square = (Square)widget;
        _consoleOutput.WriteLine($"Square {square.Position} size={square.Size}");
    }

    public bool CanDraw(Widget widget) => widget is Square;
}