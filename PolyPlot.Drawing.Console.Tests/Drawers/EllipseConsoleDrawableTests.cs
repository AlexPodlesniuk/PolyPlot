using PolyPlot.Drawing.Console.Drawers;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public class EllipseConsoleDrawableTests : ConsoleDrawingTestsBase<Ellipse>
{
    protected override Ellipse CreateDrawableWidget() => CreateEllipse();
    protected override IDrawable CreateDrawable() => new EllipseConsoleDrawable(ConsoleOutput);

    protected override string ExpectedOutput(Ellipse widget) =>
        $"Ellipse {widget.Position} diameterH = {widget.HorizontalDiameter} diameterV = {widget.VerticalDiameter}";
}