namespace PolyPlot.Widgets.Dimensions;

public readonly struct Height(int value)
{
    public int Value { get;  } = value <= 0 ? throw new ArgumentOutOfRangeException(nameof(Value), "Height must be positive") : value;
    public static Height Of(int value) => new (value);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}