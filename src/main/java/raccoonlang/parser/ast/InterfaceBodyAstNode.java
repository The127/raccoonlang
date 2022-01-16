package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class InterfaceBodyAstNode {
    public List<InterfaceMemberAstNode> interfaceMemberAstNodes = new ArrayList<>();

    public static InterfaceBodyAstNode parse(Parser parser) {
        InterfaceBodyAstNode interfaceBodyAstNode = new InterfaceBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);

        while (true){
            InterfaceMemberAstNode interfaceMemberAstNode = InterfaceMemberAstNode.tryParse(parser);
            if(interfaceMemberAstNode != null){
                interfaceBodyAstNode.interfaceMemberAstNodes.add(interfaceMemberAstNode);
            }else {
                break;
            }
        }

        parser.take(TokenType.CLOSE_CURLY);

        return interfaceBodyAstNode;
    }
}
