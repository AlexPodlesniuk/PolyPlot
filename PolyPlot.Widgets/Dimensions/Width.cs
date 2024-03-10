namespace PolyPlot.Widgets.Dimensions;

public record Width(int Value)
{
    public int Value { get;  } = Value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Width must be positive") : Value;
    public static Width Of(int value) => new Width(value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}