package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class ClassBodyAstNode {

    public List<ClassMemberAstNode> classMemberAstNodes = new ArrayList<>();

    public static ClassBodyAstNode parse(Parser parser) {
        ClassBodyAstNode classBodyAstNode = new ClassBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);

        while(true){
            ClassMemberAstNode classMemberAstNode = ClassMemberAstNode.tryParse(parser);
            if(classMemberAstNode != null){
                classBodyAstNode.classMemberAstNodes.add(classMemberAstNode);
            }else{
                break;
            }
        }

        parser.take(TokenType.CLOSE_CURLY);

        return classBodyAstNode;
    }
}
