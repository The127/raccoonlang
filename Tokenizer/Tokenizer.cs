namespace Raccoonlang.Tokenizer;

using System.Collections;
// Raccoonlang.Tokenizer.Exceptions
using Exceptions;
public class Tokenizer
{
    private ITokenMatcher[] tokenMatchers = new ITokenMatcher[]{};

    public ITokenStream tokenize(string inputFilePath, string inputFileContents) 
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

            Token matchedToken = match(inputFilePath, inputFileContents, currentString, line, column);
            if (!matchedToken.Skip) {
                tokenList.Add(matchedToken);
            }

            int matchLength = matchedToken.Text.Length;
            index += matchLength;
            column += matchLength;

        }

        return new TokenStream(inputFilePath, tokenList);

    }

    private Token match(string inputFilePath, string inputFileContents, string currentText, int line, int column) {
        foreach (ITokenMatcher tokenMatcher in tokenMatchers) {
            Token? token = tokenMatcher.Match(currentText, line, column, inputFilePath);
            if (token != null) {
                return token;
            }
        }

        throw new TokenNotRecognizedException(inputFilePath, line, column, currentText);
    }

}