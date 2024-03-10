namespace PolyPlot.Widgets.Dimensions;

public readonly struct Size(int value)
{
    public int Value { get;  } = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Size must be positive") : value;
    public static Size Of(int value) => new (value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}