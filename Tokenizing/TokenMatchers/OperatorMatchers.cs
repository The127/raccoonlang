namespace Raccoonlang.Tokenizing.TokenMatchers;

//binary operators
public class OpBinAndTokenMatcher : TokenMatcher
{
    public OpBinAndTokenMatcher() : base("&", TokenType.OP_BIN_AND) {}
}

public class OpBinOrTokenMatcher : TokenMatcher
{
    public OpBinOrTokenMatcher() : base("|", TokenType.OP_BIN_OR) {}
}

public class OpNotTokenMatcher : TokenMatcher
{
    public OpNotTokenMatcher() : base("!", TokenType.OP_NOT) {}
}

public class OpXorTokenMatcher : TokenMatcher
{
    public OpXorTokenMatcher() : base("^", TokenType.OP_XOR) {}
}

//boolean operators
public class OpBoolAndTokenMatcher : TokenMatcher
{
    public OpBoolAndTokenMatcher() : base("&&", TokenType.OP_BOOL_AND) {}
}

public class OpBoolOrTokenMatcher : TokenMatcher
{
    public OpBoolOrTokenMatcher() : base("||", TokenType.OP_BOOL_OR) {}
}

public class OpDivisionTokenMatcher : TokenMatcher
{
    public OpDivisionTokenMatcher() : base("/", TokenType.OP_DIVISION) {}
}

public class OpGreaterThanTokenMatcher : TokenMatcher
{
    public OpGreaterThanTokenMatcher() : base(">", TokenType.OP_GT) {}
}

public class OpSmallerThanTokenMatcher : TokenMatcher
{
    public OpSmallerThanTokenMatcher() : base("<", TokenType.OP_LT) {}
}

public class OpMinusTokenMatcher : TokenMatcher
{
    public OpMinusTokenMatcher() : base("-", TokenType.OP_MINUS) {}
}

public class OpModuloTokenMatcher : TokenMatcher
{
    public OpModuloTokenMatcher() : base("%", TokenType.OP_MODULO) {}
}

public class OpPlusTokenMatcher : TokenMatcher
{
    public OpPlusTokenMatcher() : base("+", TokenType.OP_PLUS) {}
}

public class OpTimesTokenMatcher : TokenMatcher
{
    public OpTimesTokenMatcher() : base("*", TokenType.OP_PLUS) {}
}