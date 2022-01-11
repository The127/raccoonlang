package raccoonlang.parser;

import raccoonlang.parser.ast.FileAstNode;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenStream;
import raccoonlang.tokenizer.TokenType;

public class Parser {

    public class ParserState {
        private int tokenIndex = 0;

        public ParserState(int tokenIndex){
            this.tokenIndex = tokenIndex;
        }
    }

    private TokenStream tokenStream;

    public Parser(TokenStream tokenStream) {
        this.tokenStream = tokenStream;
    }

    public Token peek() {
        return peek(0);
    }

    public Token peek(int lookAhead) {
        return tokenStream.peek(lookAhead);
    }

    public Token take(TokenType tokenType) {
        return tokenStream.take(tokenType);
    }

    public Token take() {
        return tokenStream.take();
    }

    public ParserState shelfState(){
        return new ParserState(tokenStream.getPosition());
    }

    public void restore(ParserState parserState){
        tokenStream.seek(parserState.tokenIndex);
    }

    public static FileAstNode parse(TokenStream tokenStream) {
        Parser parser = new Parser(tokenStream);
        FileAstNode fileAstNode = FileAstNode.parse(parser);
        parser.take(TokenType.EOF);
        return fileAstNode;
    }
}
