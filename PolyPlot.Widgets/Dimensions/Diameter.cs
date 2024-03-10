namespace PolyPlot.Widgets.Dimensions;

public record Diameter(int Value)
{
    public int Value { get;  } = Value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Diameter must be positive") : Value;
    public static Diameter Of(int value) => new Diameter(value);

    public override string ToString()
    {
        return Value.ToString();
    }
}