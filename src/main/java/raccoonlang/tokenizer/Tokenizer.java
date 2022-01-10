package raccoonlang.tokenizer;

import raccoonlang.tokenizer.matchers.*;

import java.util.ArrayList;
import java.util.List;

public class Tokenizer {

    // the order of matchers is important! put most important rules at the top
    private TokenMatcher[] tokenMatchers = new TokenMatcher[]{
            new LambdaArrowTokenMatcher(),

            new PlusEqualsTokenMatcher(),
            new MinusEqualsTokenMatcher(),
            new TimesEqualsTokenMatcher(),
            new DivisionEqualsTokenMatcher(),
            new ModuloEqualsTokenMatcher(),
            new AndEqualsTokenMatcher(),
            new OrEqualsTokenMatcher(),
            new XorEqualsTokenMatcher(),

            // lowest priority
            new OpenParenthesisTokenMatcher(),
            new CloseParenthesisTokenMatcher(),
            new OpenCurlyTokenMatcher(),
            new CloseCurlyTokenMatcher(),
            new OpenSquareTokenMatcher(),
            new CloseSquareTokenMatcher(),

            new EqualsTokenMatcher(),
            new DotTokenMatcher(),
            new CommaTokenMatcher(),
            new SemicolonTokenMatcher(),

            new I8TokenMatcher(),
            new I16TokenMatcher(),
            new I32TokenMatcher(),
            new I64TokenMatcher(),

            new U8TokenMatcher(),
            new U16TokenMatcher(),
            new U32TokenMatcher(),
            new U64TokenMatcher(),

            new F32TokenMatcher(),
            new F64TokenMatcher(),

            new BoolTokenMatcher(),
            new TrueTokenMatcher(),
            new FalseTokenMatcher(),

            new StringTokenMatcher(),

            new PublicTokenMatcher(),
            new PrivateTokenMatcher(),
            new ProtectedTokenMatcher(),
            new InternalTokenMatcher(),

            new VarTokenMatcher(),
            new DataTokenMatcher(),
            new ClassTokenMatcher(),

            new NamespaceTokenMatcher(),
            new ImportlTokenMatcher(),
    };

    public TokenStream tokenize(String inputFilePath, String fileContents) {
        List<Token> tokenList = new ArrayList<>();

        int line = 0;
        int column = 0;

        int index = 0;

        int contentLength = fileContents.length();
        while (index < contentLength) {
            String currentText = fileContents.substring(index);

            if (System.lineSeparator().equals(currentText)) {
                line++;
                column = 0;
                continue;
            }

            Token match = match(inputFilePath, fileContents, currentText, line, column);
            tokenList.add(match);

            var matchLength = match.getText().length();
            index += matchLength;
            column += matchLength;
        }

        return new TokenStreamImpl(inputFilePath, tokenList);
    }

    private Token match(String inputFilePath, String text, String currentText, int line, int column) {
        for (TokenMatcher tokenMatcher : tokenMatchers) {
            Token token = tokenMatcher.match(currentText, line, column, inputFilePath);
            if (token != null) {
                return token;
            }
        }

        throw new TokenNotRecognizedException(inputFilePath, text, line, column);
    }
}
