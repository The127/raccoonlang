namespace Raccoonlang.Tokenizing.TokenMatchers;

// public class BoolTokenMatcher : TokenMatcher
// {
//     public BoolTokenMatcher() : base("bool", TokenType.Bool) {}
// }

public class ClassTokenMatcher : TokenMatcher
{
    public ClassTokenMatcher() : base("class", TokenType.Class) {}
}

public class DataTokenMatcher : TokenMatcher
{
    public DataTokenMatcher() : base("data", TokenType.Data) {}
}

public class FalseTokenMatcher : TokenMatcher
{
    public FalseTokenMatcher() : base("false", TokenType.False) {}
}

public class FnTokenMatcher : TokenMatcher
{
    public FnTokenMatcher() : base("fn", TokenType.Fn) {}
}

public class ImportTokenMatcher : TokenMatcher
{
    public ImportTokenMatcher() : base("import", TokenType.Import) {}
}

public class InterfaceTokenMatcher : TokenMatcher
{
    public InterfaceTokenMatcher() : base("interface", TokenType.Interface) {}
}

public class ExtendsTokenMatcher : TokenMatcher
{
    public ExtendsTokenMatcher() : base("extends", TokenType.Extends) {}
}

public class ImplementsTokenMatcher : TokenMatcher
{
    public ImplementsTokenMatcher() : base("implements", TokenType.Implements) {}
}

public class InternalTokenMatcher : TokenMatcher
{
    public InternalTokenMatcher() : base("internal", TokenType.Internal) {}
}

public class NamespaceTokenMatcher : TokenMatcher
{
    public NamespaceTokenMatcher() : base("namespace", TokenType.Namespace) {}
}

public class NewTokenMatcher : TokenMatcher
{
    public NewTokenMatcher() : base("new", TokenType.New) {}
}

public class ColonColonTokenMatcher : TokenMatcher
{
    public ColonColonTokenMatcher() : base("::", TokenType.ColonColon) {}
}

public class PrivateTokenMatcher : TokenMatcher
{
    public PrivateTokenMatcher() : base("private", TokenType.Private) {}
}

public class ProtectedTokenMatcher : TokenMatcher
{
    public ProtectedTokenMatcher() : base("protected", TokenType.Protected) {}
}

public class PublicTokenMatcher : TokenMatcher
{
    public PublicTokenMatcher() : base("public", TokenType.Public) {}
}

// public class StringTokenMatcher : TokenMatcher
// {
//     public StringTokenMatcher() : base("string", TokenType.String) {}
// }

public class TrueTokenMatcher : TokenMatcher
{
    public TrueTokenMatcher() : base("true", TokenType.True) {}
}

public class VarTokenMatcher : TokenMatcher
{
    public VarTokenMatcher() : base("var", TokenType.Var) {}
}

public class LoopTokenMatcher : TokenMatcher
{
    public LoopTokenMatcher() : base("loop", TokenType.Loop) {}
}

public class IfTokenMatcher : TokenMatcher
{
    public IfTokenMatcher() : base("if", TokenType.If) {}
}

public class ElifTokenMatcher : TokenMatcher
{
    public ElifTokenMatcher() : base("elif", TokenType.Elif) {}
}

public class ElseTokenMatcher : TokenMatcher
{
    public ElseTokenMatcher() : base("else", TokenType.Else) {}
}

public class SwitchTokenMatcher : TokenMatcher
{
    public SwitchTokenMatcher() : base("switch", TokenType.Switch) {}
}


public class CaseTokenMatcher : TokenMatcher
{
    public CaseTokenMatcher() : base("case", TokenType.Case) {}
}


public class DefaultTokenMatcher : TokenMatcher
{
    public DefaultTokenMatcher() : base("default", TokenType.Default) {}
}

public class BreakTokenMatcher : TokenMatcher
{
    public BreakTokenMatcher() : base("break", TokenType.Break) {}
}

public class ContinueTokenMatcher : TokenMatcher
{
    public ContinueTokenMatcher() : base("continue", TokenType.Continue) {}
}

public class ReturnTokenMatcher : TokenMatcher
{
    public ReturnTokenMatcher() : base("return", TokenType.Return) {}
}

public class ThisTokenMatcher : TokenMatcher
{
    public ThisTokenMatcher() : base("this", TokenType.This) {}
}

public class CastTokenMatcher : TokenMatcher
{
    public CastTokenMatcher() : base("cast", TokenType.Cast) {}
}

public class BaseTokenMatcher : TokenMatcher
{
    public BaseTokenMatcher() : base("base", TokenType.Base) {}
}


public class ConstTokenMatcher : TokenMatcher
{
    public ConstTokenMatcher() : base("const", TokenType.Const) {}
}

public class WhereTokenMatcher : TokenMatcher
{
    public WhereTokenMatcher() : base("where", TokenType.Where) {}
}

public class GetTokenMatcher : TokenMatcher
{
    public GetTokenMatcher() : base("get", TokenType.Get) {}
}

public class SetTokenMatcher : TokenMatcher
{
    public SetTokenMatcher() : base("set", TokenType.Set) {}
}

public class LambdaArrowTokenMatcher : TokenMatcher
{
    public LambdaArrowTokenMatcher() : base("=>", TokenType.LambdaArrow) {}
}