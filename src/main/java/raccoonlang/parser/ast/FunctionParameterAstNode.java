package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;

public class FunctionParameterAstNode {
    public FqtnAstNode typeName;
    public Token parameterName;

    public static FunctionParameterAstNode parse(Parser parser) {
        FunctionParameterAstNode functionParameterAstNode = new FunctionParameterAstNode();
        functionParameterAstNode.typeName = FqtnAstNode.parse(parser);

    }
}
