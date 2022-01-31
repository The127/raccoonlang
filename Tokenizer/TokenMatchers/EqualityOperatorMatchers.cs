namespace Raccoonlang.Tokenizer.TokenMatchers;

public class AndEqualsTokenMatcher : TokenMatcher
{
    public AndEqualsTokenMatcher() : base("&=", TokenType.AND_EQUALS) {}
}

public class DivisionEqualsTokenMatcher : TokenMatcher
{
    public DivisionEqualsTokenMatcher() : base("/=", TokenType.DIVISION_EQUALS) {}
}

public class PlusEqualsTokenMatcher : TokenMatcher
{
    public PlusEqualsTokenMatcher() : base("+=", TokenType.PLUS_EQUALS) {}
}

public class MinusEqualsTokenMatcher : TokenMatcher
{
    public MinusEqualsTokenMatcher() : base("-=", TokenType.MINUS_EQUALS) {}
}

public class TimesEqualsTokenMatcher : TokenMatcher
{
    public TimesEqualsTokenMatcher() : base("*=", TokenType.TIMES_EQUALS) {}
}

public class OrEqualsTokenMatcher : TokenMatcher
{
    public OrEqualsTokenMatcher() : base("|=", TokenType.OR_EQUALS) {}
}

public class XorEqualsTokenMatcher : TokenMatcher
{
    public XorEqualsTokenMatcher() : base("^=", TokenType.XOR_EQUALS) {}
}