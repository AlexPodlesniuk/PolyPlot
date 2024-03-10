using FluentAssertions;
namespace PolyPlot.App.IntegrationTests;

public class DrawWidgets
{
    [Fact]
    public void AllWidgetsShouldBePrintedToConsole()
    {
        using var capture = new ConsoleOutputCapture();
        var expectedOutput = """
                             ----------------------------------------------------------------
                             Requested Drawing
                             ----------------------------------------------------------------
                             Rectangle (10,10) width=30 height=40
                             Square (15,30) size=35
                             Ellipse (100,150) diameterH = 300 diameterV = 200
                             Circle (1,1) size=300
                             Textbox (5,5) width=200 height=100 text="sample text"
                             ----------------------------------------------------------------
                             """;
        Program.Main(new string []{});
        
        var output = capture.GetOutput();
        output.Should().Contain("Requested Drawing");
        output.Should().Contain("Rectangle (10,10) width=30 height=40");
        output.Should().Contain("Square (15,30) size=35");
        output.Should().Contain("Ellipse (100,150) diameterH = 300 diameterV = 200");
        output.Should().Contain("Circle (1,1) size=300");
        output.Should().Contain("Textbox (5,5) width=200 height=100 text=\"sample text\"");
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

    public string GetOutput() => _stringWriter.ToString().TrimEnd();

    public void Dispose()
    {
        System.Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}