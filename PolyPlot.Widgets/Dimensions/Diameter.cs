namespace PolyPlot.Widgets.Dimensions;

public readonly struct Diameter(int value)
{
    public int Value { get;  } = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Diameter must be positive") : value;
    public static Diameter Of(int value) => new (value);

    public override string ToString()
    {
        return Value.ToString();
    }
}