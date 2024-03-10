using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class CircleConsoleDrawable : IDrawable
{
    private readonly IConsoleOutput _consoleOutput;
    public CircleConsoleDrawable(IConsoleOutput consoleOutput) => _consoleOutput = consoleOutput;

    public void Draw(Widget widget)
    {
        var circle = (Circle)widget;
        _consoleOutput.WriteLine($"Circle {circle.Position} size={circle.Size}");
    }

    public bool CanDraw(Widget widget) => widget is Circle;
}