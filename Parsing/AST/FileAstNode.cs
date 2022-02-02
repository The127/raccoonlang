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

        node.imports = ImportsAstNode.Parse(parser);
        node.nameSpace = NamespaceAstNode.TryParse(parser);
        node.typedefs = TypeDefinitionsAstNode.Parse(parser);

        return node;
    }

    public override string ToString()
    {
        return "FileAstNode{"+
                "imports="+          (imports == null ? "" : imports.ToString()) +
                ", nameSpace=" + (nameSpace == null ? "" : nameSpace.ToString()) +
                ", typedefs=" +    (typedefs == null ? "" : typedefs.ToString()) +
                "}";
    }
}