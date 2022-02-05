namespace Raccoonlang.Tokenizing.TokenMatchers;

public class AndEqualsTokenMatcher : TokenMatcher
{
    public AndEqualsTokenMatcher() : base("&=", TokenType.AndEquals) {}
}

public class DivisionEqualsTokenMatcher : TokenMatcher
{
    public DivisionEqualsTokenMatcher() : base("/=", TokenType.DivisionEquals) {}
}

public class PlusEqualsTokenMatcher : TokenMatcher
{
    public PlusEqualsTokenMatcher() : base("+=", TokenType.PlusEquals) {}
}

public class MinusEqualsTokenMatcher : TokenMatcher
{
    public MinusEqualsTokenMatcher() : base("-=", TokenType.MinusEquals) {}
}

public class TimesEqualsTokenMatcher : TokenMatcher
{
    public TimesEqualsTokenMatcher() : base("*=", TokenType.TimesEquals) {}
}

public class ModuloEqualsTokenMatcher : TokenMatcher
{
    public ModuloEqualsTokenMatcher() : base("%=", TokenType.ModuloEquals) {}
}

public class OrEqualsTokenMatcher : TokenMatcher
{
    public OrEqualsTokenMatcher() : base("|=", TokenType.OrEquals) {}
}

public class XorEqualsTokenMatcher : TokenMatcher
{
    public XorEqualsTokenMatcher() : base("^=", TokenType.XorEquals) {}
}