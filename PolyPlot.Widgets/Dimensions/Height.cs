namespace PolyPlot.Widgets.Dimensions;

public record Height(int Value)
{
    public int Value { get;  } = Value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Height must be positive") : Value;
    public static Height Of(int value) => new Height(value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}