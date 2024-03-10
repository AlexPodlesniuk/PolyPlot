namespace PolyPlot.Widgets.Dimensions;

public record Size(int Value)
{
    public int Value { get;  } = Value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Size must be positive") : Value;
    public static Size Of(int value) => new Size(value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}