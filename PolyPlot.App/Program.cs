using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyPlot.Drawing;
using PolyPlot.Drawing.Console;
using PolyPlot.Widgets;
using PolyPlot.Widgets.Dimensions;

namespace PolyPlot.App;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddConsoleDrawing();
            })
            .Build();

        var surface = host.Services.GetRequiredService<ISurface>();
        surface.AddWidget(
            new Rectangle(
                new Coordinate(10, 10), 
                Width.Of(30), 
                Height.Of(40))
        );
        surface.AddWidget(
            new Square(new Coordinate(15, 30), 
                Size.Of(35))
        );
        surface.AddWidget(
            new Ellipse(
                new Coordinate(100, 150), 
                Diameter.Of(300), 
                Diameter.Of(200))
        );
        surface.AddWidget(
            new Circle(
                new Coordinate(1, 1), 
                Diameter.Of(300))
        );
        surface.AddWidget(
            new Textbox(
                new Coordinate(5, 5), 
                Width.Of(200), 
                Height.Of(100), "sample text")
        );

        surface.Draw();
    }
}