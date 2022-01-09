package raccoonlang.tokenizer;

public class Token {

    private TokenType tokenType;
    private int line;
    private int column;
    private String text;
    private String fileName;

    public Token(TokenType tokenType, int line, int column, String text, String fileName){
        this.tokenType = tokenType;
        this.line = line;
        this.column = column;
        this.text = text;
        this.fileName = fileName;
    }

    public TokenType getTokenType() {
        return tokenType;
    }

    public int getLine() {
        return line;
    }

    public int getColumn() {
        return column;
    }

    public String getText() {
        return text;
    }

    @Override
    public String toString() {
        return "Token{" +
                "tokenType=" + tokenType +
                ", line=" + line +
                ", column=" + column +
                ", text='" + text + '\'' +
                '}';
    }
}
