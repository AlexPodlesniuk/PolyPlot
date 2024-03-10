using AutoFixture;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.Drawing.Console.Tests.Customizations;

internal class PositiveSizeCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Size>(composer =>
            composer.FromFactory<int>(value =>
                Size.Of(value > 0 ? value : -value + 1)));
    }
}