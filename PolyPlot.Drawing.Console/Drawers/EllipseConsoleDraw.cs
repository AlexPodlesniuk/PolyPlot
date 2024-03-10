using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class EllipseConsoleDrawable : IDrawable
{
    public IRenderOutput Draw(Widget widget)
    {
        var ellipse = (Ellipse)widget;
        return new ConsoleRenderOutput($"Ellipse {ellipse.Position} diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}");
    }

    public bool CanDraw(Widget widget) => widget is Ellipse;
}