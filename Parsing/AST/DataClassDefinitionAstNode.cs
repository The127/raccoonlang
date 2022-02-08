using LLVMSharp;

namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class DataClassDefinitionAstNode : ITypeDef
{
    public ModifiersAstNode? Modifiers { get; set; }
    public Token? Name { get; set; }
    public GenericTypesAstNode? GenericTypes { get; set; }
    public FunctionParametersAstNode? Parameters { get; set; }
    public GenericTypeConstraintsAstNode? GenericConstraints { get; set; }
    public DataClassBodyAstNode? BodyContainer { get; set; }

    public static DataClassDefinitionAstNode? TryParse(Parser parser)
    {
        DataClassDefinitionAstNode node = new DataClassDefinitionAstNode();

        var parserState = parser.ShelfState();
        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.Data)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.Data);
        parser.Take(TokenType.Class);
        
        node.Name = parser.Take(TokenType.Identifier);
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        node.Parameters = FunctionParametersAstNode.Parse(parser);
        node.GenericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.BodyContainer = DataClassBodyAstNode.Parse(parser);

        return node;
    }

    public override string ToString()
    {
        return "DataClassDefinitionAstNode{" +
                "modifiersAstNode=" + Modifiers +
                ", name=" + Name +
                ", genericTypesAstNode=" + GenericTypes +
                ", functionParametersAstNode=" + Parameters +
                ", genericTypeConstraintsAstNode=" + GenericConstraints+
                ", dataClassBodyAstNode=" + BodyContainer +
                "}";
    }

    public void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module)
    {
        throw new NotImplementedException();
    }
}