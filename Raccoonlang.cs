using Raccoonlang.Utils;

namespace Raccoonlang;

using System;

using Tokenizing;
using Parsing;
using Parsing.AST;

class Raccoonlang
{
    static void Main(string[] args)
    {
        Tokenizer tokenizer = new Tokenizer();
        ITokenStream stream = tokenizer.Tokenize("hardcoded_test.rcn",
        "namespace help.me;\n" +
        "public interface IPerson{" +
        "   u8 Age {get}" +
        "   string GetFullName();" +
        "   fn string StaticFunction();" +
        "}" +
        "\n" +
        "private class Person implements IPerson{" +
        "   u8 Age {get}" +
        "   string GetFulName() => \"John Doe\";" +
        "   fn string StaticFunction(){" +
        "       /* TODO statements */" +
        "   }" +
        "}" +
        "\n" +
        "public data class Point2d(f64 X, f64 Y);\n" +
        "\n" +
        "public data class Complex(f64 X, f64 Y){" +
        "   u16 Something => 42;" +
        "}\n" +
        "\n" +
        "/* multiline comment\n" +
        "testing */\n" +       
        "public fn void main() { //optionally string[] args or smth\n" + 
        "}");

        FileAstNode ast = Parser.Parse((TokenStream) stream);
        Console.WriteLine(ast.AutoToString(prettyPrint:false));
    }
}
