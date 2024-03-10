namespace PolyPlot.Drawing.Console;

public interface IConsolePrinter
{
    public void WriteLine(string line);
}

internal sealed class ConsolePrinter : IConsolePrinter
{
    public void WriteLine(string line) => System.Console.WriteLine(line);
}