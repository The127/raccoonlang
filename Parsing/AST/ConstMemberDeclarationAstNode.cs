using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class ConstMemberDeclarationAstNode
{
    public ModifiersAstNode Modifiers { get; set; }
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public MemberInitializationTermAstNode Initialization { get; set; }
    
    public static ConstMemberDeclarationAstNode? TryParse(Parser parser)
    {
        ConstMemberDeclarationAstNode node = new();
        var parserState = parser.ShelfState();

        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.Const)
        {
            parser.RestoreState(parserState);
            return null;
        }

        node.Type = FqtnAstNode.Parse(parser);
        node.Name = parser.Take(TokenType.Identifier);
        node.Name = parser.Take(TokenType.Equals);
        node.Initialization = MemberInitializationTermAstNode.Parse(parser);
        node.Name = parser.Take(TokenType.Semicolon);
        
        return node;
    }
}