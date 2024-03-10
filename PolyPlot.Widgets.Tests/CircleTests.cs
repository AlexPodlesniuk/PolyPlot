using FluentAssertions;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets.Tests;

public class CircleTests
{
    [Fact]
    public void CircleCannotBeConstructedWithNegativeValue()
    {
        var action = () => new Circle(new Coordinate(0,0), new Diameter(-1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Diameter must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void CircleCannotBeConstructedWithZeroValue()
    {
        var action = () => new Circle(new Coordinate(0,0), new Diameter(0));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Diameter must be positive (Parameter 'Value')");
    }

    [Fact]
    public void ValidCircleCanBeConstructed()
    {
        var circle = new Circle(new Coordinate(0,0), new Diameter(1));
        circle.Should().NotBeNull();
    }
}