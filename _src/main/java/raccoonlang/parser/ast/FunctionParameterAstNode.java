package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class FunctionParameterAstNode {
    public FqtnAstNode typeName;
    public Token parameterName;

    public static FunctionParameterAstNode parse(Parser parser) {
        FunctionParameterAstNode functionParameterAstNode = new FunctionParameterAstNode();
        functionParameterAstNode.typeName = FqtnAstNode.parse(parser);
        functionParameterAstNode.parameterName = parser.take(TokenType.IDENTIFIER);
        return functionParameterAstNode;
    }

    @Override
    public String toString() {
        return "FunctionParameterAstNode{" +
                "typeName=" + typeName.toString() +
                ", parameterName=" + parameterName.toString() +
                '}';
    }
}
