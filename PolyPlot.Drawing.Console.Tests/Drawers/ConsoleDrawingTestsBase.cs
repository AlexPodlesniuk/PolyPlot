using FluentAssertions;
using NSubstitute;
using PolyPlot.Widgets;

namespace PolyPlot.Drawing.Console.Tests.Drawers;

public abstract class ConsoleDrawingTestsBase<T> : TestBase where T : Widget
{
    protected readonly IConsolePrinter ConsolePrinter = Substitute.For<IConsolePrinter>();
    
    protected abstract T CreateDrawableWidget();
    protected abstract IDrawable CreateDrawable();
    protected abstract string ExpectedOutput(T widget);
    
    [Fact]
    public void CanDraw_ReturnsFalse_WhenWidgetHasDifferentType()
    {
        var drawable = CreateDrawable();
        drawable.CanDraw(CreateDummyWidget()).Should().BeFalse();
    }

    [Fact]
    public void CanDraw_ReturnsTrue_WhenWidgetHasProperType()
    {
        var drawable = CreateDrawable();
        drawable.CanDraw(CreateDrawableWidget()).Should().BeTrue();
    }
    
    [Fact]
    public void Draw_ReturnsConsoleRepresentation_WhenCirclePassed()
    {
        var widget = CreateDrawableWidget();
        var drawable = CreateDrawable();
        var res = (ConsoleRenderOutput)drawable.Draw(widget);

        res.RenderedOutput.Should().Be(ExpectedOutput(widget));
    }
}