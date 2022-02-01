package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class DataClassBodyAstNode {
    public List<DataClassMemberAstNode> dataClassMemberAstNodes = new ArrayList<>();

    public static DataClassBodyAstNode parse(Parser parser) {
        DataClassBodyAstNode dataClassAstNode = new DataClassBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);

        while(true){
            DataClassMemberAstNode dataClassMemberAstNode = DataClassMemberAstNode.tryParse(parser);
            if(dataClassMemberAstNode != null) {
                dataClassAstNode.dataClassMemberAstNodes.add(dataClassMemberAstNode);
            }else{
                break;
            }
        }

        parser.take(TokenType.CLOSE_CURLY);

        return dataClassAstNode;
    }
}
