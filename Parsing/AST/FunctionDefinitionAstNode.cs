using LLVMSharp;

namespace Raccoonlang.Parsing.AST;

using Tokenizing;
using Utils;

public class FunctionDefinitionAstNode : ITypeDef
{
    public ModifiersAstNode Modifiers { get; set; }
    public FqtnAstNode ReturnType { get; set; }
    public Token Name { get; set; }
    public GenericTypesAstNode? GenericTypes { get; set; }
    public FunctionParametersAstNode Param { get; set; }
    public GenericTypeConstraintsAstNode GenericConstraints { get; set; }
    public FunctionBodyAstNode BodyContainer { get; set; }

    public static FunctionDefinitionAstNode? TryParse(Parser parser)
    {

        FunctionDefinitionAstNode node = new FunctionDefinitionAstNode();

        var parserState = parser.ShelfState();
        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.Fn)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.Fn);

        node.ReturnType = FqtnAstNode.Parse(parser);
        node.Name = parser.Take(TokenType.Identifier);
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        node.Param = FunctionParametersAstNode.Parse(parser);
        node.GenericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.BodyContainer = FunctionBodyAstNode.Parse(parser);

        return node;
    }

    public override string ToString() => $"FunctionDefinitionAstNode={{Modifiers={Modifiers}, ReturnType={ReturnType}, Name={Name}, GenericTypes={GenericTypes}, Param={Param}, GenericConstraints={GenericConstraints}, BodyContainer={BodyContainer}}}";
    
    public void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module)
    {
        
        // module.AddFunction(Name.Text, )
        CompilerLogger.Error("Compiling functions is not implemented yet!");
        Environment.Exit(1);
    }
}