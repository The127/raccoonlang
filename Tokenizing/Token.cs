namespace Raccoonlang.Tokenizing;

public class Token
{
    public TokenType Type {get; private set;}
    public int Line {get; private set;}
    public int Column {get; private set;}
    public string Text {get; private set;}
    public string FileName {get; private set;}
    public bool Skip {get; private set;}

    public Token(TokenType type, int line, int column, string text, string fileName)
    {
        this.Type = type;
        this.Line = line;
        this.Column = column;
        this.Text = text;
        this.FileName = fileName;
        this.Skip = false;
    }
    
    public Token(TokenType type, int line, int column, string text, string fileName, bool skip)
    {
        this.Type = type;
        this.Line = line;
        this.Column = column;
        this.Text = text;
        this.FileName = fileName;
        this.Skip = skip;
    }
}