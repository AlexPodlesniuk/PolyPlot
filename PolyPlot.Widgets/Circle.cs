using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets;

public record Circle(Coordinate Position, Diameter Size) : Widget(Position);