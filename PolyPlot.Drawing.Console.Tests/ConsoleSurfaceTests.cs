using FluentAssertions;
using NSubstitute;
using PolyPlot.Drawing.Console.Drawers;

namespace PolyPlot.Drawing.Console.Tests;

public class ConsoleSurfaceTests : TestBase
{
    private readonly IConsolePrinter _consolePrinter = Substitute.For<IConsolePrinter>();
    
    [Fact]
    public void Draw_WithNoWidgets_PrintsOnlyHeaderAndFooter()
    {
        var drawables = Enumerable.Empty<IDrawable>();
        var surface = new ConsoleSurface(_consolePrinter, drawables);
        surface.Render();
        
        var expectedOutput1 = """
                             ----------------------------------------------------------------
                             Requested Drawing
                             ----------------------------------------------------------------
                             """;
        var expectedOutput2 = "----------------------------------------------------------------";
        
        _consolePrinter.Received(1).WriteLine(Arg.Is(expectedOutput1));
        _consolePrinter.Received(1).WriteLine(Arg.Is(expectedOutput2));
    }
    
    [Fact]
    public void Draw_ThrowsException_WhenWidgetDrawerNotFound()
    {
        var drawables = Enumerable.Empty<IDrawable>();
        var surface = new ConsoleSurface(_consolePrinter, drawables);
        var widget = CreateDummyWidget();
        surface.AddWidget(widget);
        
        var act = () => surface.Render();
        
        act.Should().Throw<InvalidOperationException>().WithMessage($"No drawable found for widget {widget.GetType()}");
    }
    
    [Fact]
    public void Draw_DrawsWidget_WhenWidgetAddedAndDrawerExists()
    {
        var circleDrawer = new CircleConsoleDrawable();
        var squareDrawer = new SquareConsoleDrawable();
        var drawables = new IDrawable[] { circleDrawer, squareDrawer };
        var surface = new ConsoleSurface(_consolePrinter, drawables);
        var circle = CreateCircle();
        var square = CreateSquare();
        surface.AddWidget(circle);
        surface.AddWidget(square);
        
        surface.Render();
        
        _consolePrinter.Received(1).WriteLine(Arg.Is($"Circle {circle.Position} size={circle.Size}"));
        _consolePrinter.Received(1).WriteLine(Arg.Is($"Square {square.Position} size={square.Size}"));
    }
}