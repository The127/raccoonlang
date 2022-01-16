package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;

public class InterfaceMemberAstNode {

    public InterfaceMethodDeclarationAstNode interfaceMethodDeclarationAstNode;
    public boolean isInterfaceMethodDeclaration;

    public InterfaceFunctionDeclarationAstNode interfaceFunctionDeclarationAstNode;
    public boolean isInterfaceFunctionDeclaration;

    public InterfacePropertyDeclarationAstNode interfacePropertyDeclarationAstNode;
    public boolean isInterfacePropertyDeclaration;

    public static InterfaceMemberAstNode tryParse(Parser parser) {
        InterfaceMemberAstNode interfaceMemberAstNode = new InterfaceMemberAstNode();

        interfaceMemberAstNode.interfaceMethodDeclarationAstNode = InterfaceMethodDeclarationAstNode.tryParse(parser);
        if(interfaceMemberAstNode.interfaceMethodDeclarationAstNode == null){
            interfaceMemberAstNode.isInterfaceMethodDeclaration = true;
        }else{
            return interfaceMemberAstNode;
        }

        interfaceMemberAstNode.interfaceFunctionDeclarationAstNode = InterfaceFunctionDeclarationAstNode.tryParse(parser);
        if(interfaceMemberAstNode.interfaceFunctionDeclarationAstNode == null){
            interfaceMemberAstNode.isInterfaceFunctionDeclaration = true;
        }else{
            return interfaceMemberAstNode;
        }

        interfaceMemberAstNode.interfacePropertyDeclarationAstNode = InterfacePropertyDeclarationAstNode.tryParse(parser);
        if(interfaceMemberAstNode.interfacePropertyDeclarationAstNode == null){
            interfaceMemberAstNode.isInterfacePropertyDeclaration = true;
        }else{
            return interfaceMemberAstNode;
        }

        return null;
    }
}
