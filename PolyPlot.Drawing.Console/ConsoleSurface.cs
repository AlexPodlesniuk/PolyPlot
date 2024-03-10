using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console;

public sealed class ConsoleSurface : ISurface
{
    private readonly List<Widget> _widgets = new ();
    private readonly IConsolePrinter _consolePrinter;
    private readonly IEnumerable<IDrawable> _drawables;


    public ConsoleSurface(IConsolePrinter consolePrinter, IEnumerable<IDrawable> drawables)
    {
        _consolePrinter = consolePrinter;
        _drawables = drawables;
    }

    public void AddWidget(Widget widget) => _widgets.Add(widget);

    public void Render()
    {
        _consolePrinter.WriteLine("""
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

            if (drawable.Draw(widget) is not ConsoleRenderOutput output)
            {
                throw new InvalidOperationException($"Drawable {drawable.GetType()} returned invalid output");
            }
            
            _consolePrinter.WriteLine(output.RenderedOutput);
        }
        _consolePrinter.WriteLine("----------------------------------------------------------------");
    }
}