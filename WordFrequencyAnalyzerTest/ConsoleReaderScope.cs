using System;
using System.IO;
using static WordFrequencyAnalyzerTest.UserInputTests;

public class ConsoleReaderScope : IDisposable
{
    private TextReader _originalInput;
    private StringReader _stringReader;

    public ConsoleReaderScope(string input)
    {
        _originalInput = Console.In;
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);
    }

    public ConsoleReaderScope(IConsoleReader consoleReader)
    {
        _originalInput = Console.In;
        Console.SetIn(new ConsoleReaderAdapter(consoleReader));
    }

    public void Dispose()
    {
        Console.SetIn(_originalInput);
        _stringReader?.Dispose();
    }
}

public class ConsoleWriterScope : IDisposable
{
    private TextWriter _originalOutput;
    private StringWriter _stringWriter;

    public ConsoleWriterScope()
    {
        _originalOutput = Console.Out;
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }

    public ConsoleWriterScope(IConsoleWriter consoleWriter)
    {
        _originalOutput = Console.Out;
        Console.SetOut(new ConsoleWriterAdapter(consoleWriter));
    }

    public string GetOutput()
    {
        return _stringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter?.Dispose();
    }
}

internal class ConsoleReaderAdapter : TextReader
{
    private readonly IConsoleReader _consoleReader;

    public ConsoleReaderAdapter(IConsoleReader consoleReader)
    {
        _consoleReader = consoleReader;
    }

    public override string ReadLine()
    {
        return _consoleReader.ReadLine();
    }
}

internal class ConsoleWriterAdapter : TextWriter
{
    private readonly IConsoleWriter _consoleWriter;

    public ConsoleWriterAdapter(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public override void WriteLine(string value)
    {
        _consoleWriter.WriteLine(value);
    }

    public override System.Text.Encoding Encoding => System.Text.Encoding.Default;
}
