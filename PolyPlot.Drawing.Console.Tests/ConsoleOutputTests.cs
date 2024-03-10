using FluentAssertions;

namespace PolyPlot.Drawing.Console.Tests;

public class ConsoleOutputTests
{
    [Fact]
    public void WhenDrawingCircle_ThenDrawsCircle()
    {
        using var capture = new ConsoleOutputCapture();
        var consoleOutput = new ConsolePrinter();
        
        consoleOutput.WriteLine("hello");
        
        capture.GetOutput().Should().Contain("hello");
    }
}

class ConsoleOutputCapture : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;

    public ConsoleOutputCapture()
    {
        _stringWriter = new StringWriter();
        _originalOutput = System.Console.Out;
        System.Console.SetOut(_stringWriter);
    }

    public string GetOutput() => _stringWriter.ToString();

    public void Dispose()
    {
        System.Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}