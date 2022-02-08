namespace Raccoonlang.Utils;

using Tokenizing;

public static class CompilerLogger
{
    public static void Error(Token tok, string message)
    {
        Console.Write($"{tok.FileName}:{tok.Line}:{tok.Column} | [");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERR");
        Console.ResetColor();
        Console.Write($"] - {message}\n");
    }

    public static void Error(string message)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERR");
        Console.ResetColor();
        Console.Write($"] - {message}\n");
    }

    public static void Warning(Token tok, string message)
    {
        Console.Write($"{tok.FileName}:{tok.Line}:{tok.Column} | [");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("WRN");
        Console.ResetColor();
        Console.Write($"] - {message}\n");
    }

    public static void Warning(string message)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("WRN");
        Console.ResetColor();
        Console.Write($"] - {message}\n");   
    }
    
    public static void Info(Token tok, string message)
    {
        Console.Write($"{tok.FileName}:{tok.Line}:{tok.Column} | [");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("INF");
        Console.ResetColor();
        Console.Write($"] - {message}\n");
    }

    public static void Info(string message)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("INF");
        Console.ResetColor();
        Console.Write($"] - {message}\n");
    }
}