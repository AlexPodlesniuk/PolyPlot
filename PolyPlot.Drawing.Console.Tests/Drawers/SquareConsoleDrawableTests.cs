using PolyPlot.Drawing.Console.Drawers;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public class SquareConsoleDrawableTests : ConsoleDrawingTestsBase<Square>
{
    protected override Square CreateDrawableWidget() => CreateSquare();
    protected override IDrawable CreateDrawable() => new SquareConsoleDrawable(ConsoleOutput);

    protected override string ExpectedOutput(Square widget) => $"Square {widget.Position} size={widget.Size}";
}