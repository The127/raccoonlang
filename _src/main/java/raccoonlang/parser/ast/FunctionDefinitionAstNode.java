package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class FunctionDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public FqtnAstNode returnType;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;
    public FunctionParametersAstNode funcitonParametersAstNode;
    public GenericTypeConstraintsAstNode genericTypeConstraintsAstNode;
    public FunctionBodyAstNode functionBodyAstNode;

    public static FunctionDefinitionAstNode tryParse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();
        FunctionDefinitionAstNode functionDefinitionAstNode = new FunctionDefinitionAstNode();

        functionDefinitionAstNode.modifiersAstNode = ModifiersAstNode.parse(parser);

        if(parser.peek().getTokenType() != TokenType.FN) {
            parser.restore(parserState);
            System.out.println("function");
            return null;
        }
        parser.take();

        functionDefinitionAstNode.returnType = FqtnAstNode.parse(parser);
        functionDefinitionAstNode.name = parser.take(TokenType.IDENTIFIER);
        functionDefinitionAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);
        functionDefinitionAstNode.funcitonParametersAstNode = FunctionParametersAstNode.parse(parser);
        functionDefinitionAstNode.genericTypeConstraintsAstNode = GenericTypeConstraintsAstNode.parse(parser);
        functionDefinitionAstNode.functionBodyAstNode = FunctionBodyAstNode.parse(parser);

        return functionDefinitionAstNode;
    }
}
