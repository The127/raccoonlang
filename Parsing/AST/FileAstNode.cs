using LLVMSharp;

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
                "imports="+ Imports +
                ", nameSpace=[" + NameSpace +
                "], typedefs=["+ string.Join(", ", Typedefs.NodeList) +
                "]}";
    }

    public void Compile()
    {
        var module = new Module(NameSpace?.Compile() ?? "Module");
        var context = module.GetModuleContext();
        var irBuilder = new IRBuilder(context);
        // ignore imports for now we are single file baby
        Typedefs.Compile(context, irBuilder, module);
    }
}