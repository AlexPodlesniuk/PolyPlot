namespace PolyPlot.Widgets.Dimensions;

public record Coordinate(int X, int Y)
{
    public override string ToString()
    {
        return $"({X},{Y})";
    }
}