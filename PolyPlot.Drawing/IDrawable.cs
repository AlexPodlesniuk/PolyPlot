using PolyPlot.Widgets;

namespace PolyPlot.Drawing;

public interface IDrawable
{
    bool CanDraw(Widget widget);
    void Draw(Widget widget);
}