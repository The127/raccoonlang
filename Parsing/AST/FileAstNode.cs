namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FileAstNode
{
    public ImportsAstNode Imports { get; set; }
    public NamespaceAstNode? NameSpace { get; set; }
    public TypeDefinitionsAstNode Typedefs { get; set; }

    public static FileAstNode Parse(Parser parser)
    {
        FileAstNode node = new FileAstNode();

        node.NameSpace = NamespaceAstNode.TryParse(parser);
        node.Imports = ImportsAstNode.Parse(parser);
        node.Typedefs = TypeDefinitionsAstNode.Parse(parser);

        return node;
    }

    public override string ToString()
    {
        return "FileAstNode{"+
                "imports="+ (Imports == null ? "null" : string.Join(", ", Imports.ImportNodes)) +
                ", nameSpace=" + (NameSpace == null ? "null" : (NameSpace.Node == null ? "''": string.Join(", ", NameSpace.Node.Identifiers))) +
                ", typedefs=" + (Typedefs == null ? "null" : string.Join(", ", Typedefs.NodeList)) +
                "}";
    }
}