using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class SquareConsoleDrawable : IDrawable
{
    public IRenderOutput Draw(Widget widget)
    {
        var square = (Square)widget;
        return new ConsoleRenderOutput($"Square {square.Position} size={square.Size}");
    }

    public bool CanDraw(Widget widget) => widget is Square;
}