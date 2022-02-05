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
        Parser.ParserState state = parser.ShelfState();

        FunctionDefinitionAstNode node = new FunctionDefinitionAstNode();

        if (parser.Peek().Type != TokenType.FN) {
            Console.WriteLine("Restored state in FunctionDefinition");
            parser.RestoreState(state);
            return null;
        }

        parser.Take();

        node.returnType = FqtnAstNode.Parse(parser);
        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.param = FunctionParametersAstNode.Parse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = FunctionBodyAstNode.Parse(parser);

        return node;
    }
}