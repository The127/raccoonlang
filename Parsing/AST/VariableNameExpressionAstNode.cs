using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class VariableNameTermAstNode
{
    public List<Token> NameParts { get; set; } = new();
    
    public static VariableNameTermAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("oh noes");
        return node;
    }

    public static VariableNameTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();

        if (parser.Peek().Type != TokenType.Identifier) return null;
        
        VariableNameTermAstNode node = new();
        node.NameParts.Add(parser.Take(TokenType.Identifier));
        while (parser.Peek().Type == TokenType.Dot)
        {
            parser.Take(TokenType.Dot);
            
            if (parser.Peek().Type != TokenType.Identifier)
            {
                parser.RestoreState(parserState);
                return null;
            }
            node.NameParts.Add(parser.Take(TokenType.Identifier));
        }
        return node;
    }
}