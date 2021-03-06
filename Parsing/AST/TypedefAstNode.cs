using LLVMSharp;

namespace Raccoonlang.Parsing.AST;

public class TypeDefinitionsAstNode
{
    public List<TypeDefAstNode> NodeList { get; set; } = new();

    public static TypeDefinitionsAstNode Parse(Parser parser)
    {
        TypeDefinitionsAstNode node = new TypeDefinitionsAstNode();

        while (true)
        {
            TypeDefAstNode? typeNode = TypeDefAstNode.TryParse(parser);
            if (typeNode == null) break;
            node.NodeList.Add(typeNode);
        }

        return node;
    }

    public override string ToString() => $"TypeDefinitionsAstNode{{[{string.Join(",", NodeList)}]}}";

    public void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module)
    {
        foreach (var typeDefAstNode in NodeList)
        {
            typeDefAstNode.Compile(context, irBuilder, module);
        }
    }
}

public class TypeDefAstNode
{
    public ITypeDef TypeDef { get; set; }

    public static TypeDefAstNode? TryParse(Parser parser)
    {
        ITypeDef? def = InterfaceDefinitionAstNode.TryParse(parser) as ITypeDef
                       ?? ClassDefinitionAstNode.TryParse(parser) as ITypeDef
                       ?? DataClassDefinitionAstNode.TryParse(parser) as ITypeDef
                       ?? FunctionDefinitionAstNode.TryParse(parser) as ITypeDef;
        if (def == null) return null;
        return new(){TypeDef = def};
    }

    public override string ToString() => $"TypeDefAstNode{{\nTypeDef={TypeDef}}}";

    public void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module)
    {
        TypeDef.Compile(context, irBuilder, module);
    }
}

public interface ITypeDef
{
    void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module);
}