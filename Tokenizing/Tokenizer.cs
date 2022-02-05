namespace Raccoonlang.Tokenizing;

using System.Collections;

using Exceptions;
using TokenMatchers;

public class Tokenizer
{
    private ITokenMatcher[] tokenMatchers = new ITokenMatcher[]{
        
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
            new OpenParenTokenMatcher(),
            new CloseParenTokenMatcher(),
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
            new ImportTokenMatcher(),

            new OpSmallerThanTokenMatcher(),
            new OpGreaterThanTokenMatcher(),

            new WhiteSpaceTokenMatcher(),

            // lowest priority
            new IdentifierTokenMatcher()
    };

    public ITokenStream Tokenize(string inputFilePath, string inputFileContents) 
    {
        inputFileContents = inputFileContents.Replace("\r\n", "\n").Replace("\r", "\n");
        
        List<Token> tokenList = new List<Token>();

        int line = 0;
        int column = 0;
        int index = 0;

        int contentLen = inputFileContents.Length;

        while(index < contentLen)
        {
            String currentString = inputFileContents.Substring(index);

            if (currentString.StartsWith('\n'))
            {
                line++;
                column = 0;
                index++;
                continue;
            }

            Token matchedToken = this.Match(inputFilePath, inputFileContents, currentString, line, column);
            if (!matchedToken.Skip) {
                tokenList.Add(matchedToken);
            }

            int matchLength = matchedToken.Text.Length;
            index += matchLength;
            column += matchLength;

        }

        tokenList.Add(new Token(TokenType.EOF, line, column, "\0", inputFilePath)); // specify end of file otherwise we crash
        return new TokenStream(inputFilePath, tokenList);

    }

    private Token Match(string inputFilePath, string inputFileContents, string currentText, int line, int column) {
        foreach (ITokenMatcher tokenMatcher in tokenMatchers) {
            Token? token = tokenMatcher.Match(currentText, line, column, inputFilePath);
            if (token != null) {
                Console.WriteLine(tokenMatcher);
                return token;
            }
        }

        throw new TokenNotRecognizedException(inputFilePath, line, column, currentText);
    }

}