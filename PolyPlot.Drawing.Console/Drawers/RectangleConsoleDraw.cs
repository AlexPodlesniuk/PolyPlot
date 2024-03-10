using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class RectangleConsoleDrawable : IDrawable
{
    public IRenderOutput Draw(Widget widget)
    {
        var rectangle = (Rectangle)widget;
        return new ConsoleRenderOutput($"Rectangle {rectangle.Position} width={rectangle.Width} height={rectangle.Height}");
    }

    public bool CanDraw(Widget widget) => widget.GetType().FullName == typeof(Rectangle).FullName;
}