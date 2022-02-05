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
        DataClassDefinitionAstNode node = new DataClassDefinitionAstNode();

        if (parser.Peek(1).Type != TokenType.DATA) return null;

        node.modifiers = ModifiersAstNode.Parse(parser);

        parser.Skip(3); // skip the data token and whitespaces

        parser.Take(TokenType.CLASS);

        parser.Skip(); // skip whitespace

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