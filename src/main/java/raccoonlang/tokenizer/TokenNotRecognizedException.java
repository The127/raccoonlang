package raccoonlang.tokenizer;

public class TokenNotRecognizedException extends RuntimeException {
    public TokenNotRecognizedException(String filePath, String fileContent, int line, int column) {
        super(filePath + ":" + line + ":" + column + "|" + " Unknown token found near " + fileContent);
    }
}
