package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class FunctionParametersAstNode {
    public List<FunctionParameterAstNode> functionParameterAstNodeList = new ArrayList<>();

    public static FunctionParametersAstNode parse(Parser parser) {
        FunctionParametersAstNode funcitonParametersAstNode = new FunctionParametersAstNode();
        parser.take(TokenType.OPEN_PAREN);

        funcitonParametersAstNode.functionParameterAstNodeList.add(FunctionParameterAstNode.parse(parser));

        parser.take(TokenType.CLOSE_PAREN);
        return funcitonParametersAstNode;
    }
}
