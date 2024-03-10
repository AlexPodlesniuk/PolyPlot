using FluentAssertions;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets.Tests;

public class RectangleTests
{
    [Fact]
    public void RectangleCannotBeConstructedWithNegativeWidth()
    {
        var action = () => new Rectangle(new Coordinate(0,0), Width.Of(-1), Height.Of(1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Width must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void RectangleCannotBeConstructedWithNegativeHeight()
    {
        var action = () => new Rectangle(new Coordinate(0,0), Width.Of(1), Height.Of(-1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Height must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void ValidRectangleCanBeConstructed()
    {
        var circle =  new Rectangle(new Coordinate(0,0), Width.Of(1), Height.Of(1));
        circle.Should().NotBeNull();
    }
}