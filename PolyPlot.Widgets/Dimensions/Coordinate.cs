namespace PolyPlot.Widgets.Dimensions;

public readonly struct Coordinate(int x, int y)
{
    public override string ToString()
    {
        return $"({x},{y})";
    }
}