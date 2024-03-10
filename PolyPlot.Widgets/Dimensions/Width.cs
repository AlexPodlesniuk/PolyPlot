namespace PolyPlot.Widgets.Dimensions;

public readonly struct Width(int value)
{
    public int Value { get;  } = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Width must be positive") : value;
    public static Width Of(int value) => new (value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}