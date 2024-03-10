using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console;

public sealed class ConsoleSurface : ISurface
{
    private readonly List<Widget> _widgets = new ();
    private readonly IConsoleOutput _consoleOutput;
    private readonly IEnumerable<IDrawable> _drawables;


    public ConsoleSurface(IConsoleOutput consoleOutput, IEnumerable<IDrawable> drawables)
    {
        _consoleOutput = consoleOutput;
        _drawables = drawables;
    }

    public void AddWidget(Widget widget) => _widgets.Add(widget);

    public void Draw()
    {
        _consoleOutput.WriteLine("""
                                 ----------------------------------------------------------------
                                 Requested Drawing
                                 ----------------------------------------------------------------
                                 """);
        foreach (var widget in _widgets)
        {
            var drawable = _drawables.FirstOrDefault(d => d.CanDraw(widget));
            if (drawable is null)
            {
                throw new InvalidOperationException($"No drawable found for widget {widget.GetType()}");
            }

            drawable.Draw(widget);
        }
        _consoleOutput.WriteLine("----------------------------------------------------------------");
    }
}