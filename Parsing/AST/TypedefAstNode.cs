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

    public override string ToString() => $"TypeDefinitionsAstNode{{{NodeList.ToArray()}}}";
}

public class TypeDefAstNode
{
    public ITypeDef TypeDef { get; set; }

    public static TypeDefAstNode? TryParse(Parser parser)
    {
        TypeDefAstNode node = new TypeDefAstNode();

        node.TypeDef = InterfaceDefinitionAstNode.TryParse(parser);
        if (node.TypeDef != null) return node;

        node.TypeDef = ClassDefinitionAstNode.TryParse(parser);
        if (node.TypeDef != null) return node;

        node.TypeDef = DataClassDefinitionAstNode.TryParse(parser);
        if (node.TypeDef != null) return node;

        node.TypeDef = FunctionDefinitionAstNode.TryParse(parser);
        if (node.TypeDef != null) return node;

        return null;
    }

    public override string ToString() => $"TypeDefAstNode{{{TypeDef}}}";
}

public interface ITypeDef
{
}