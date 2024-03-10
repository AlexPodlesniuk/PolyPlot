using PolyPlot.Drawing.Console.Drawers;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public class CircleConsoleDrawableTests : ConsoleDrawingTestsBase<Circle>
{
    protected override Circle CreateDrawableWidget() => CreateCircle();
    protected override IDrawable CreateDrawable() => new CircleConsoleDrawable();

    protected override string ExpectedOutput(Circle widget) => $"Circle {widget.Position} size={widget.Size}";
}