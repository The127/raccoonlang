package raccoonlang.tokenizer;

public class Token {

    private TokenType tokenType;
    private int line;
    private int column;
    private String text;
    private String fileName;
    private boolean skip;

    public Token(TokenType tokenType, int line, int column, String text, String fileName) {
        this(tokenType, line, column, text, fileName, false);
    }

    public Token(TokenType tokenType, int line, int column, String text, String fileName, boolean skip){
        this.tokenType = tokenType;
        this.line = line;
        this.column = column;
        this.text = text;
        this.fileName = fileName;
        this.skip = skip;
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

    public String getFileName() {
        return fileName;
    }

    public boolean isSkip() {
        return skip;
    }
}
