namespace Raccoonlang.Tokenizing.TokenMatchers;

//binary operators
public class OpBinAndTokenMatcher : TokenMatcher
{
    public OpBinAndTokenMatcher() : base("&", TokenType.OpBinAnd) {}
}

public class OpBinOrTokenMatcher : TokenMatcher
{
    public OpBinOrTokenMatcher() : base("|", TokenType.OpBinOr) {}
}

public class OpNotTokenMatcher : TokenMatcher
{
    public OpNotTokenMatcher() : base("!", TokenType.OpNot) {}
}

public class OpXorTokenMatcher : TokenMatcher
{
    public OpXorTokenMatcher() : base("^", TokenType.OpXor) {}
}

//boolean operators
public class OpBoolAndTokenMatcher : TokenMatcher
{
    public OpBoolAndTokenMatcher() : base("&&", TokenType.OpBoolAnd) {}
}

public class OpBoolOrTokenMatcher : TokenMatcher
{
    public OpBoolOrTokenMatcher() : base("||", TokenType.OpBoolOr) {}
}

public class OpDivisionTokenMatcher : TokenMatcher
{
    public OpDivisionTokenMatcher() : base("/", TokenType.OpDivision) {}
}

public class OpGreaterThanTokenMatcher : TokenMatcher
{
    public OpGreaterThanTokenMatcher() : base(">", TokenType.OpGt) {}
}

public class OpSmallerThanTokenMatcher : TokenMatcher
{
    public OpSmallerThanTokenMatcher() : base("<", TokenType.OpLt) {}
}

public class OpMinusTokenMatcher : TokenMatcher
{
    public OpMinusTokenMatcher() : base("-", TokenType.OpMinus) {}
}

public class OpModuloTokenMatcher : TokenMatcher
{
    public OpModuloTokenMatcher() : base("%", TokenType.OpModulo) {}
}

public class OpPlusTokenMatcher : TokenMatcher
{
    public OpPlusTokenMatcher() : base("+", TokenType.OpPlus) {}
}

public class OpTimesTokenMatcher : TokenMatcher
{
    public OpTimesTokenMatcher() : base("*", TokenType.OpPlus) {}
}