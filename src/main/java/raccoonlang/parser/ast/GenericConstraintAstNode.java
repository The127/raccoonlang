package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class GenericConstraintAstNode {

    public boolean isNew;
    public NewConstraintParametersAstNode newConstraintParametersAstNode;

    public boolean isImplements;
    public FqtnAstNode implementsType;

    public static GenericConstraintAstNode parse(Parser parser) {
        GenericConstraintAstNode genericConstraintsAstNode = new GenericConstraintAstNode();

        if(parser.peek().getTokenType() == TokenType.NEW){
            parser.take();
            genericConstraintsAstNode.isNew = true;
            genericConstraintsAstNode.newConstraintParametersAstNode = NewConstraintParametersAstNode.tryParse(parser);
        }else{
            genericConstraintsAstNode.isImplements = true;
            genericConstraintsAstNode.implementsType = FqtnAstNode.parse(parser);
        }

        return genericConstraintsAstNode;
    }
}
