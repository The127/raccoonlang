package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class FunctionDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;
    public FunctionParametersAstNode funcitonParametersAstNode;

    public static FunctionDefinitionAstNode tryParse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();
        FunctionDefinitionAstNode functionDefinitionAstNode = new FunctionDefinitionAstNode();

        functionDefinitionAstNode.modifiersAstNode = ModifiersAstNode.parse(parser);

        if(parser.peek().getTokenType() != TokenType.FN) {
            parser.restore(parserState);
            return null;
        }
        parser.take();

        functionDefinitionAstNode.name = parser.take(TokenType.IDENTIFIER);
        functionDefinitionAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);
        functionDefinitionAstNode.funcitonParametersAstNode = FunctionParametersAstNode.parse(parser);

        return functionDefinitionAstNode;
    }
}
