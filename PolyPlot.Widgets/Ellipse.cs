using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets;

public record Ellipse(Coordinate Position, Diameter HorizontalDiameter, Diameter VerticalDiameter) : Widget(Position);