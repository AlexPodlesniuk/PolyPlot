using AutoFixture;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Drawing.Console.Tests.Customizations;

internal class PositiveHeightCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Height>(composer =>
            composer.FromFactory<int>(value =>
                Height.Of(value > 0 ? value : -value + 1)));
    }
}