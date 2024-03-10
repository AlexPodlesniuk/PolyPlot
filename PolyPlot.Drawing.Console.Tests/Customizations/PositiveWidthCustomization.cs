using AutoFixture;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Drawing.Console.Tests.Customizations;

internal class PositiveWidthCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Width>(composer =>
            composer.FromFactory<int>(value =>
                Width.Of(value > 0 ? value : -value + 1)));
    }
}