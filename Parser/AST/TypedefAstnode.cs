namespace Raccoonlang.Parser.AST;

public class TypeDefAstNode
{
    public InterfaceDefinitionAstNode? interfaceNode;
    public ClassDefinitionAstNode? classNode;

    public static TypeDefAstNode? TryParse(Parser parser) {
        return null;
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