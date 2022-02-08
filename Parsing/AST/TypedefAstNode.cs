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
}

public interface ITypeDef
{
}