using FluentAssertions;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets.Tests;

public class EllipseTests
{
    [Fact]
    public void EllipseCannotBeConstructedWithNegativeValue()
    {
        var action = () => new Ellipse(new Coordinate(0,0), new Diameter(-1), new Diameter(-1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Diameter must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void EllipseCannotBeConstructedWithZeroValue()
    {
        var action = () => new Ellipse(new Coordinate(0,0), new Diameter(0), new Diameter(-1));
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Diameter must be positive (Parameter 'Value')");
    }

    [Fact]
    public void ValidEllipseCanBeConstructed()
    {
        var circle = new Ellipse(new Coordinate(0,0), new Diameter(1), new Diameter(1));
        circle.Should().NotBeNull();
    }
}