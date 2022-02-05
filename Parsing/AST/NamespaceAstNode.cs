namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class NamespaceAstNode
{
    public FqtnAstNode? Node {get; set;}

    public static NamespaceAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Namespace) return null;

        NamespaceAstNode node = new NamespaceAstNode();
        parser.Take(TokenType.Namespace);
        node.Node = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.Semicolon);

        return node;
    }

    public override string ToString() => $"NamespaceAstNode={{\nNode={Node}}}";
}