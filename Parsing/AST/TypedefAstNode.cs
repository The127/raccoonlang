namespace Raccoonlang.Parsing.AST;

public class TypeDefAstNode
{
    public InterfaceDefinitionAstNode? interfaceNode;
    public ClassDefinitionAstNode? classNode;
    public DataClassDefinitionAstNode? dataNode;
    public FunctionDefinitionAstNode? funcNode;

    public static TypeDefAstNode? TryParse(Parser parser)
    {
        TypeDefAstNode node = new TypeDefAstNode();

        node.interfaceNode = InterfaceDefinitionAstNode.TryParse(parser);
        if (node.interfaceNode != null) return node;

        node.classNode = ClassDefinitionAstNode.TryParse(parser);
        if (node.classNode != null) return node;

        node.dataNode = DataClassDefinitionAstNode.TryParse(parser);
        if (node.dataNode != null) return node;

        node.funcNode = FunctionDefinitionAstNode.TryParse(parser);
        
        return (node.funcNode == null) ? null : node; 
    } 
}

public class TypeDefinitionsAstNode
{
    public List<TypeDefAstNode> nodeList = new List<TypeDefAstNode>();

    public static TypeDefinitionsAstNode Parse(Parser parser)
    {
        TypeDefinitionsAstNode node = new TypeDefinitionsAstNode();

        while(true) {
            TypeDefAstNode? typeNode = TypeDefAstNode.TryParse(parser);
            if (typeNode == null) break;
            node.nodeList.Add(typeNode); 
        }

        return node;
    }
}