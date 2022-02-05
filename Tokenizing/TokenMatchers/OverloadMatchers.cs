namespace Raccoonlang.Tokenizing.TokenMatchers;

public class OverloadDivisionTokenMatcher : TokenMatcher
{
    public OverloadDivisionTokenMatcher() : base("operator/", TokenType.OverloadDivision) {}
}

public class OverloadMinusTokenMatcher : TokenMatcher
{
    public OverloadMinusTokenMatcher() : base("operator-", TokenType.OverloadMinus) {} 
}

public class OverloadPlusTokenMatcher : TokenMatcher
{
    public OverloadPlusTokenMatcher() : base("operator+", TokenType.OverloadPlus) {}
}

public class OverloadTimesTokenMatcher : TokenMatcher
{
    public OverloadTimesTokenMatcher() : base("operator*", TokenType.OverloadTimes) {}
}

public class OverloadModuloTokenMatcher : TokenMatcher
{
    public OverloadModuloTokenMatcher() : base("operator%", TokenType.OverloadModulo) {}
}