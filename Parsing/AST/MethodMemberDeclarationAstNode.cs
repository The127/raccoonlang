using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class MethodMemberDeclarationAstNode
{
    public ModifiersAstNode Modifiers { get; set; }
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public GenericTypesAstNode? Generics { get; set; }
    public FunctionParametersAstNode Parameters { get; set; }
    public GenericTypeConstraintsAstNode Constraints { get; set; }
    public FunctionBodyAstNode Body { get; set; }
    
    public static MethodMemberDeclarationAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();

        MethodMemberDeclarationAstNode node = new();
        node.Modifiers = ModifiersAstNode.Parse(parser);

        var type = FqtnAstNode.TryParse(parser);
        if (type == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Type = type;

        if (parser.Peek().Type != TokenType.Identifier)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Name = parser.Take(TokenType.Identifier);
        
        node.Generics = GenericTypesAstNode.TryParse(parser);

        var parameters = FunctionParametersAstNode.TryParse(parser);
        if (parameters == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Parameters = parameters;
        
        node.Constraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.Body = FunctionBodyAstNode.Parse(parser);

        return node;
    }
}