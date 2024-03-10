using FluentAssertions;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets.Tests;

public class SquareTests
{
    [Fact]
    public void SquareCannotBeConstructedWithNegativeValue()
    {
        var action = () => new Square(new Coordinate(0,0), new Size(-1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Size must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void SquareCannotBeConstructedWithZeroValue()
    {
        var action = () => new Square(new Coordinate(0,0), new Size(0));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Size must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void ValidSquareCanBeConstructed()
    {
        var circle = new Square(new Coordinate(0,0), new Size(1));
        circle.Should().NotBeNull();
    }
}