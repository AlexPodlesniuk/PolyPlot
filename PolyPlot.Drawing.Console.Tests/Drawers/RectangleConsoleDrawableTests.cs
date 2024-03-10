using PolyPlot.Drawing.Console.Drawers;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public class RectangleConsoleDrawableTests : ConsoleDrawingTestsBase<Rectangle>
{
    protected override Rectangle CreateDrawableWidget() => CreateRectangle();
    protected override IDrawable CreateDrawable() => new RectangleConsoleDrawable();

    protected override string ExpectedOutput(Rectangle widget) =>
        $"Rectangle {widget.Position} width={widget.Width} height={widget.Height}";
}