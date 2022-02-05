namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FileAstNode
{
    public ImportsAstNode? imports;
    public NamespaceAstNode? nameSpace;
    public TypeDefinitionsAstNode? typedefs;

    public static FileAstNode Parse(Parser parser)
    {
        FileAstNode node = new FileAstNode();

        node.nameSpace = NamespaceAstNode.TryParse(parser);
        node.imports = ImportsAstNode.Parse(parser);
        node.typedefs = TypeDefinitionsAstNode.Parse(parser);

        return node;
    }

    public override string ToString()
    {
        return "FileAstNode{"+
                "imports="+ (imports == null ? "null" : string.Join(", ", imports.ImportNodes)) +
                ", nameSpace=" + (nameSpace == null ? "null" : (nameSpace.Node == null ? "''": string.Join(", ", nameSpace.Node.Identifiers))) +
                ", typedefs=" + (typedefs == null ? "null" : string.Join(", ", typedefs.nodeList)) +
                "}";
    }
}