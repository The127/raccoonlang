namespace Raccoonlang.Tokenizing.TokenMatchers;

public class BoolTokenMatcher : TokenMatcher
{
    public BoolTokenMatcher() : base("bool", TokenType.BOOL) {}
}

public class ClassTokenMatcher : TokenMatcher
{
    public ClassTokenMatcher() : base("class", TokenType.CLASS) {}
}

public class DataTokenMatcher : TokenMatcher
{
    public DataTokenMatcher() : base("data", TokenType.DATA) {}
}

public class FalseTokenMatcher : TokenMatcher
{
    public FalseTokenMatcher() : base("data", TokenType.FALSE) {}
}

public class FnTokenMatcher : TokenMatcher
{
    public FnTokenMatcher() : base("fn", TokenType.FN) {}
}

public class ImportTokenMatcher : TokenMatcher
{
    public ImportTokenMatcher() : base("import", TokenType.IMPORT) {}
}

public class InterfaceTokenMatcher : TokenMatcher
{
    public InterfaceTokenMatcher() : base("interface", TokenType.INTERFACE) {}
}

public class InternalTokenMatcher : TokenMatcher
{
    public InternalTokenMatcher() : base("internal", TokenType.INTERNAL) {}
}

public class NamespaceTokenMatcher : TokenMatcher
{
    public NamespaceTokenMatcher() : base("namespace", TokenType.NAMESPACE) {}
}

public class NewTokenMatcher : TokenMatcher
{
    public NewTokenMatcher() : base("new", TokenType.NEW) {}
}

public class PrivateTokenMatcher : TokenMatcher
{
    public PrivateTokenMatcher() : base("private", TokenType.PRIVATE) {}
}

public class ProtectedTokenMatcher : TokenMatcher
{
    public ProtectedTokenMatcher() : base("protected", TokenType.PROTECTED) {}
}

public class PublicTokenMatcher : TokenMatcher
{
    public PublicTokenMatcher() : base("public", TokenType.PUBLIC) {}
}

public class StringTokenMatcher : TokenMatcher
{
    public StringTokenMatcher() : base("string", TokenType.STRING) {}
}

public class TrueTokenMatcher : TokenMatcher
{
    public TrueTokenMatcher() : base("true", TokenType.TRUE) {}
}

public class VarTokenMatcher : TokenMatcher
{
    public VarTokenMatcher() : base("var", TokenType.VAR) {}
}

public class WhereTokenMatcher : TokenMatcher
{
    public WhereTokenMatcher() : base("where", TokenType.WHERE) {}
}

public class LambdaArrowTokenMatcher : TokenMatcher
{
    public LambdaArrowTokenMatcher() : base("=>", TokenType.LAMBDA_ARROW) {}
}