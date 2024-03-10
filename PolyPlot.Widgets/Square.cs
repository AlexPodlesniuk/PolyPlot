using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets;

public record Square(Coordinate Position, Size Size) : Widget(Position);
