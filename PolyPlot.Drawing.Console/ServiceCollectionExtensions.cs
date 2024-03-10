using Microsoft.Extensions.DependencyInjection;

namespace PolyPlot.Drawing.Console;

public static class ServiceCollectionExtensions
{
    public static void AddConsoleDrawing(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<DrawingConsoleAssemblyReference>()
            .AddClasses(classes => classes.AssignableTo<IDrawable>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddTransient<ISurface, ConsoleSurface>();
        services.AddTransient<IConsoleOutput, ConsoleOutput>();
    }
}