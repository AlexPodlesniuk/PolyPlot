using PolyPlot.Widgets;

namespace PolyPlot.Drawing;

public interface ISurface
{
    public void AddWidget(Widget widget);
    public void Draw();
}