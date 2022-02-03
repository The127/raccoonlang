namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class NamespaceAstNode
{
    public FqtnAstNode? Node {get; private set;}

    public static NamespaceAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.NAMESPACE) {
            return null;
        }

        NamespaceAstNode node = new NamespaceAstNode();
        parser.Take(TokenType.NAMESPACE);
        parser.Take(TokenType.WHITE_SPACE);
        node.Node = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.SEMICOLON);

        return node;
    }
}