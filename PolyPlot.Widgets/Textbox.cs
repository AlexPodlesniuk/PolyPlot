using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets;

public record Textbox(Coordinate Position, Width Width, Height Height, string Text) : Rectangle(Position, Width, Height);
