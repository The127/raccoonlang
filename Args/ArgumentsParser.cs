namespace Raccoonlang.Args;

using Tokenizing;
using System.IO;

public class ArgumentsParser 
{
    public static bool ParseArguments(string[] args)
    {
        if (args.Length < 2) {
            return false;
        }

        switch(args[1]) {
            case "compile": 
                Tokenizer tokenizer = new Tokenizer();
                if (args.Length == 3) {
                    try {
                        string path = args[2];
                        tokenizer.Tokenize(path, File.ReadAllText(path));
                    } catch (Exception e)
                    {
                        throw;
                    }
                }
                break;
            case "help":
                return true;
            default:
                Console.WriteLine("Don't recognize this option!");
                return false;
        }

        return true;
    }
}