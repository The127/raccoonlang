package raccoonlang.parser;

import raccoonlang.parser.ast.FileAstNode;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenStream;
import raccoonlang.tokenizer.TokenType;

public class Parser {

    public class ParserState {
        private int tokenIndex = 0;

        public ParserState clone(){
            ParserState clone = new ParserState();
            clone.tokenIndex = this.tokenIndex;
            return clone;
        }
    }

    private ParserState parserState = new ParserState();
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
        parserState.tokenIndex++;
        return tokenStream.take(tokenType);
    }

    public Token take() {
        parserState.tokenIndex++;
        return tokenStream.take();
    }

    public ParserState copyState(){
        return parserState.clone();
    }

    public void restore(ParserState parserState){
        this.parserState.tokenIndex = parserState.tokenIndex;
    }

    public static FileAstNode parse(TokenStream tokenStream) {
        Parser parser = new Parser(tokenStream);
        FileAstNode fileAstNode = FileAstNode.parse(parser);
        parser.take(TokenType.EOF);
        return fileAstNode;
    }
}
