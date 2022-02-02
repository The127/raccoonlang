namespace Raccoonlang.Tokenizing.TokenMatchers;

// floating point
public class F32TokenMatcher : TokenMatcher
{
    public F32TokenMatcher() : base("f32", TokenType.F32) {}
}

public class F64TokenMatcher : TokenMatcher
{
    public F64TokenMatcher() : base("f64", TokenType.F64) {}
}

// unsigned int
public class U8TokenMatcher : TokenMatcher
{
    public U8TokenMatcher() : base("u8", TokenType.U8) {}
}

public class U16TokenMatcher : TokenMatcher
{
    public U16TokenMatcher() : base("u16", TokenType.U16) {}
}

public class U32TokenMatcher : TokenMatcher
{
    public U32TokenMatcher() : base("u32", TokenType.U32) {}
}

public class U64TokenMatcher : TokenMatcher
{
    public U64TokenMatcher() : base("u64", TokenType.U64) {}
}

// signed int
public class I8TokenMatcher : TokenMatcher
{
    public I8TokenMatcher() : base("i8", TokenType.I8) {}
}

public class I16TokenMatcher : TokenMatcher
{
    public I16TokenMatcher() : base("i16", TokenType.I16) {}
}

public class I32TokenMatcher : TokenMatcher
{
    public I32TokenMatcher() : base("i32", TokenType.I32) {}
}

public class I64TokenMatcher : TokenMatcher
{
    public I64TokenMatcher() : base("i64", TokenType.I64) {}
}