namespace Raccoonlang.Tokenizing.TokenMatchers;

public class OverloadDivisionTokenMatcher : TokenMatcher
{
    public OverloadDivisionTokenMatcher() : base("operator/", TokenType.OVERLOAD_DIVISION) {}
}

public class OverloadMinusTokenMatcher : TokenMatcher
{
    public OverloadMinusTokenMatcher() : base("operator-", TokenType.OVERLOAD_MINUS) {} 
}

public class OverloadPlusTokenMatcher : TokenMatcher
{
    public OverloadPlusTokenMatcher() : base("operator+", TokenType.OVERLOAD_PLUS) {}
}

public class OverloadTimesTokenMatcher : TokenMatcher
{
    public OverloadTimesTokenMatcher() : base("operator*", TokenType.OVERLOAD_TIMES) {}
}

public class OverloadModuloTokenMatcher : TokenMatcher
{
    public OverloadModuloTokenMatcher() : base("operator%", TokenType.OVERLOAD_MODULO) {}
}