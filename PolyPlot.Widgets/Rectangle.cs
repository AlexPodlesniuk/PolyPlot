using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets;
public record Rectangle(Coordinate Position, Width Width, Height Height) : Widget(Position);
