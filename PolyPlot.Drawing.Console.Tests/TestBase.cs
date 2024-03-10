using AutoFixture;
using PolyPlot.Widgets;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Drawing.Console.Tests;

public class TestBase
{
    protected readonly Fixture WidgetsFixture;

    protected TestBase()
    {
        WidgetsFixture = new Fixture();
        WidgetsFixture.Customize(new Customizations.PositiveDiameterCustomization());
        WidgetsFixture.Customize(new Customizations.PositiveHeightCustomization());
        WidgetsFixture.Customize(new Customizations.PositiveWidthCustomization());
        WidgetsFixture.Customize(new Customizations.PositiveSizeCustomization());
    }
    
    protected Circle CreateCircle() => WidgetsFixture.Create<Circle>();
    protected Rectangle CreateRectangle() => WidgetsFixture.Create<Rectangle>();
    protected Square CreateSquare() => WidgetsFixture.Create<Square>();
    protected Textbox CreateTextbox() => WidgetsFixture.Create<Textbox>();
    protected Ellipse CreateEllipse() => WidgetsFixture.Create<Ellipse>();
    protected DummyWidget CreateDummyWidget() => WidgetsFixture.Create<DummyWidget>();
}

public record DummyWidget(Coordinate Position) : Widget(Position);