package raccoonlang.tokenizer;

import raccoonlang.tokenizer.matchers.*;

import java.util.ArrayList;
import java.util.List;

public class Tokenizer {

    // the order of matchers is important! put most important rules at the top
    private TokenMatcher[] tokenMatchers = new TokenMatcher[]{

            // highest priority
            new OverloadPlusTokenMatcher(),
            new OverloadMinusTokenMatcher(),
            new OverloadTimesTokenMatcher(),
            new OverloadDivisionTokenMatcher(),
            new OverloadModuloTokenMatcher(),

            // high priority
            new StringLiteralTokenMatcher(),
            new CommentTokenMatcher(),
            new MultiLineCommentTokenMatcher(),
            new NumberLiteralTokenMatcher(),

            // medium priority
            new LambdaArrowTokenMatcher(),

            new PlusEqualsTokenMatcher(),
            new MinusEqualsTokenMatcher(),
            new TimesEqualsTokenMatcher(),
            new DivisionEqualsTokenMatcher(),
            new ModuloEqualsTokenMatcher(),
            new AndEqualsTokenMatcher(),
            new OrEqualsTokenMatcher(),
            new XorEqualsTokenMatcher(),

            new OpBinOrTokenMatcher(),
            new OpBinAndTokenMatcher(),

            // low priority
            new OpenParenthesisTokenMatcher(),
            new CloseParenthesisTokenMatcher(),
            new OpenCurlyTokenMatcher(),
            new CloseCurlyTokenMatcher(),
            new OpenSquareTokenMatcher(),
            new CloseSquareTokenMatcher(),

            new OpPlusTokenMatcher(),
            new OpMinusTokenMatcher(),
            new OpTimesTokenMatcher(),
            new OpDivisionTokenMatcher(),
            new OpModuloTokenMatcher(),

            new OpBinAndTokenMatcher(),
            new OpBinOrTokenMatcher(),

            new OpXorTokenMatcher(),

            new OpNotTokenMatcher(),

            new EqualsTokenMatcher(),
            new DotTokenMatcher(),
            new CommaTokenMatcher(),
            new SemicolonTokenMatcher(),
            new ColonTokenMatcher(),

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
            new InterfaceTokenMatcher(),
            new FnTokenMatcher(),

            new WhereTokenMatcher(),
            new NewTokenMatcher(),

            new NamespaceTokenMatcher(),
            new ImportlTokenMatcher(),

            new OpLtTokenMatcher(),
            new OpGtTokenMatcher(),

            new WhiteSpaceTokenMatcher(),

            // lowest priority
            new IdentifierTokenMatcher(),
    };

    public TokenStream tokenize(String inputFilePath, String fileContents) {
        fileContents = fileContents
                .replaceAll("\r\n", "\n")
                .replaceAll("\r", "\n");

        List<Token> tokenList = new ArrayList<>();

        int line = 0;
        int column = 0;

        int index = 0;

        int contentLength = fileContents.length();
        while (index < contentLength) {
            String currentText = fileContents.substring(index);

            if (currentText.startsWith("\n")) {
                line++;
                column = 0;
                index++;
                continue;
            }

            Token match = match(inputFilePath, fileContents, currentText, line, column);
            if(!match.isSkip()){
                tokenList.add(match);
            }

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

        throw new TokenNotRecognizedException(inputFilePath, currentText, line, column);
    }
}
