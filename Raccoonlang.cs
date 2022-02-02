namespace Raccoonlang;

using System;

using Tokenizing;
using Parsing;
using Parsing.AST;

class Raccoonlang
{
    static void Main(string[] args)
    {
        Console.WriteLine("raccoonlang compiler...");

        Tokenizer tokenizer = new Tokenizer();
        ITokenStream stream = tokenizer.Tokenize("a",
        "namespace help.me;\n" +
        "public data class Point2das(f64 X f64 Y){\n" +
        "}\n" +
        "\n" +        
        "public fn void main() { //optionally string[] args or smth\n" + 
        "}");

        Console.WriteLine("amount of tokens: {0}", stream.Size());
        FileAstNode ast = Parser.Parse((TokenStream) stream);
        Console.WriteLine(ast);


    }
}
