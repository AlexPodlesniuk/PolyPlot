using AutoFixture;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Drawing.Console.Tests.Customizations;

internal class PositiveDiameterCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Diameter>(composer =>
            composer.FromFactory<int>(value =>
                Diameter.Of(value > 0 ? value : -value + 1)));
    }
}