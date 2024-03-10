using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Drawers;

internal sealed class EllipseConsoleDrawable : IDrawable
{
    private readonly IConsoleOutput _consoleOutput;
    public EllipseConsoleDrawable(IConsoleOutput consoleOutput) => _consoleOutput = consoleOutput;
    public void Draw(Widget widget)
    {
        var ellipse = (Ellipse)widget;
        _consoleOutput.WriteLine($"Ellipse {ellipse.Position} diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}");
    }

    public bool CanDraw(Widget widget) => widget is Ellipse;
}