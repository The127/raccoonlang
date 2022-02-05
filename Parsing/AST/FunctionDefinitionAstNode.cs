namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionDefinitionAstNode
{
    public ModifiersAstNode? modifiers;
    public FqtnAstNode? returnType;
    public Token? name;
    public GenericTypesAstNode? genericTypes;
    public FunctionParametersAstNode? param;
    public GenericTypeConstraintsAstNode? genericConstraints;
    public FunctionBodyAstNode? bodyContainer;

    public static FunctionDefinitionAstNode? TryParse(Parser parser)
    {

        FunctionDefinitionAstNode node = new FunctionDefinitionAstNode();

        if (parser.Peek(1).Type != TokenType.FN) return null;

        node.modifiers = ModifiersAstNode.Parse(parser);

        parser.Skip(); // skip the fn token

        node.returnType = FqtnAstNode.Parse(parser);
        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.param = FunctionParametersAstNode.Parse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = FunctionBodyAstNode.Parse(parser);

        return node;
    }
}