package raccoonlang;

import raccoonlang.tokenizer.TokenStream;
import raccoonlang.tokenizer.TokenType;
import raccoonlang.tokenizer.Tokenizer;

public class Main {

    public static void main(String[] args) {
        Tokenizer testee = new Tokenizer();
        TokenStream stream = testee.tokenize("fake", "()");
        System.out.println(stream.size());
        System.out.println(stream.take(TokenType.OPEN_PAREN));
        System.out.println(stream.take(TokenType.CLOSE_PAREN));
        System.out.println(stream.take(TokenType.EOF));
        if (!ArgumentsParser.parseArguments(args)) {
            printUsage();
        }
    }

    public static void printUsage() {
        System.out.println("Usage: raccoon compile file.rcn");
    }

}
