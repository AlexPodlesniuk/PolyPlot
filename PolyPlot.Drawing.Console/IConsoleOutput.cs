namespace PolyPlot.Drawing.Console;

public interface IConsoleOutput
{
    public void WriteLine(string line);
}

internal sealed class ConsoleOutput : IConsoleOutput
{
    public void WriteLine(string line) => System.Console.WriteLine(line);
}