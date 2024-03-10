using FluentAssertions;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Widgets.Tests;

public class TextboxTests
{
    [Fact]
    public void TextboxCannotBeConstructedWithNegativeWidth()
    {
        var action = () => new Textbox(new Coordinate(0,0), Width.Of(-1), Height.Of(1), "Hello, World!");
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Width must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void TextboxCannotBeConstructedWithNegativeHeight()
    {
        var action = () => new Textbox(new Coordinate(0,0), Width.Of(1), Height.Of(-1), "Hello, World!");
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Height must be positive (Parameter 'Value')");
    }
    
    [Fact]
    public void ValidTextboxCanBeConstructed()
    {
        var circle =  new Textbox(new Coordinate(0,0), Width.Of(1), Height.Of(1), "Hello, World!");
        circle.Should().NotBeNull();
    }
}