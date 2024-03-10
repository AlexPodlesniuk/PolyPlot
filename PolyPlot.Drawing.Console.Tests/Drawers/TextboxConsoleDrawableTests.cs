using PolyPlot.Drawing.Console.Drawers;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public class TextboxConsoleDrawableTests : ConsoleDrawingTestsBase<Textbox>
{
    protected override Textbox CreateDrawableWidget() => CreateTextbox();
    protected override IDrawable CreateDrawable() => new TextboxConsoleDrawable(ConsoleOutput);

    protected override string ExpectedOutput(Textbox widget) => $"Textbox {widget.Position} width={widget.Width} height={widget.Height} text=\"{widget.Text}\"";
}