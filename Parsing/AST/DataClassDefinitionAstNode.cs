namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class DataClassDefinitionAstNode
{
    public ModifiersAstNode? modifiers;
    public Token? name;
    public GenericTypesAstNode? genericTypes;
    public FunctionParametersAstNode? parameters;
    public GenericTypeConstraintsAstNode? genericConstraints;
    public DataClassBodyAstNode? bodyContainer;

    public static DataClassDefinitionAstNode? TryParse(Parser parser)
    {
        Parser.ParserState state = parser.ShelfState();

        DataClassDefinitionAstNode node = new DataClassDefinitionAstNode();

        node.modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.DATA) {
            parser.RestoreState(state);
            return null;
        }

        parser.Take();
        parser.Take(TokenType.CLASS);

        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.parameters = FunctionParametersAstNode.Parse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = DataClassBodyAstNode.Parse(parser);

        return node;
    }

    public override string ToString()
    {
        return "DataClassDefinitionAstNode{" +
                "modifiersAstNode=" + modifiers +
                ", name=" + name +
                ", genericTypesAstNode=" + (genericTypes == null ? "" : genericTypes.ToString()) +
                ", functionParametersAstNode=" + parameters +
                ", genericTypeConstraintsAstNode=" + genericConstraints+
                ", dataClassBodyAstNode=" + bodyContainer +
                "}";
    }
}