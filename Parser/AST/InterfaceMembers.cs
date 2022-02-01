namespace Raccoonlang.Parser.AST;

public class InterfaceMemberAstNode
{
    public InterfaceMethodDeclarationAstNode? methodNode;
    public bool isMethodDecl;

    public InterfaceFunctionDeclarationAstNode? functionNode;
    public bool isFunctionDecl;

    public InterfacePropertyDeclarationAstNode? propertyNode;
    public bool isPropertyDecl;

    public static InterfaceMemberAstNode? TryParse(Parser parser)
    {
        InterfaceMemberAstNode node = new InterfaceMemberAstNode();

        node.methodNode = InterfaceMethodDeclarationAstNode.TryParse(parser);
        if (node.methodNode == null) {
            node.isMethodDecl = true;
        } else {
            return node;
        }

        node.functionNode = InterfaceFunctionDeclarationAstNode.TryParse(parser);
        if (node.functionNode == null) {
            node.isFunctionDecl = true;
        } else {
            return node;
        }

        node.propertyNode = InterfacePropertyDeclarationAstNode.TryParse(parser);
        if (node.propertyNode == null) {
            node.isPropertyDecl = true;
        } else {
            return node;
        }

        return null;
    }
}

public class InterfaceMethodDeclarationAstNode
{
    public static InterfaceMethodDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}

public class InterfaceFunctionDeclarationAstNode
{
    public static InterfaceFunctionDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}

public class InterfacePropertyDeclarationAstNode
{
    public static InterfacePropertyDeclarationAstNode? TryParse(Parser parser)
    {
        return null;
    }
}