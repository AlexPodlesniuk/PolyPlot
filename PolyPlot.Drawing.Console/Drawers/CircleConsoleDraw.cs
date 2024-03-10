using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class CircleConsoleDrawable : IDrawable
{
    public IRenderOutput Draw(Widget widget)
    {
        var circle = (Circle)widget;
        return new ConsoleRenderOutput($"Circle {circle.Position} size={circle.Size}");
    }

    public bool CanDraw(Widget widget) => widget is Circle;
}