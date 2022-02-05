namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class NamespaceAstNode
{
    public FqtnAstNode? Node {get; private set;}

    public static NamespaceAstNode? TryParse(Parser parser)
    {
        var peek = parser.Peek().Type;
        if (peek != TokenType.NAMESPACE) {
            Console.WriteLine("tried to parse namespace");
            return null;
        }

        NamespaceAstNode node = new NamespaceAstNode();
        parser.Take(TokenType.NAMESPACE);
        Console.WriteLine("Took namespace token");
        parser.Take(TokenType.WHITE_SPACE);
        node.Node = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.SEMICOLON);

        return node;
    }
}