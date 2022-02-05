namespace Raccoonlang.Parsing.AST;

public class InterfaceMemberAstNode
{
    public IInterfaceMember? Member { get; set; }

    public static InterfaceMemberAstNode Parse(Parser parser)
    {
        InterfaceMemberAstNode node = new InterfaceMemberAstNode();

        node.Member = InterfaceMethodDeclarationAstNode.TryParse(parser);
        if (node.Member != null) return node;

        node.Member = InterfaceFunctionDeclarationAstNode.TryParse(parser);
        if (node.Member != null) return node;

        node.Member = InterfacePropertyDeclarationAstNode.TryParse(parser);
        if (node.Member == null) return node;

        throw new System.Exception("fucked up");
    }
}

public interface IInterfaceMember
{
    
}

public class InterfaceMethodDeclarationAstNode : IInterfaceMember
{
    public static InterfaceMethodDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}

public class InterfaceFunctionDeclarationAstNode : IInterfaceMember
{
    public static InterfaceFunctionDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}

public class InterfacePropertyDeclarationAstNode : IInterfaceMember
{
    public static InterfacePropertyDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}