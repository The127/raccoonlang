namespace Raccoonlang.Tokenizing;

public enum TokenType
{
    OpenParen,     // (
    CloseParen,    // )
    OpenCurly,     // {
    CloseCurly,    // }
    OpenSquare,    // [
    CloseSquare,   // ]

    Dot,            // .
    Comma,          // ,
    Semicolon,      // ;
    Colon,          // :

    Equals,         // =
    PlusEquals,    // +=
    MinusEquals,   // -=
    TimesEquals,   // *=
    DivisionEquals,// /=
    ModuloEquals,  // %=
    AndEquals,     // &=
    OrEquals,      // |=
    XorEquals,     // ^=

    OpPlus,        // +
    OpMinus,       // -
    OpTimes,       // *
    OpDivision,    // /
    OpModulo,      // %
    OpBinAnd,     // &
    OpBinOr,      // |
    OpBoolAnd,    // &&
    OpBoolOr,     // ||
    OpXor,         // ^

    OpLt,          // <
    OpGt,          // >

    OverloadPlus,
    OverloadMinus,
    OverloadTimes,
    OverloadDivision,
    OverloadModulo,

    OpNot,         // !

    LambdaArrow,   // =>

    Where,
    New,

    Public,
    Private,
    Protected,
    Internal,
    Override, //TODO

    Get,
    Set,
    
    Data,
    Class,
    Interface,
    Fn,
    Identifier,
    Var,

    // temporarily removed
    // F64,
    // F32,

    // I8,
    // I16,
    // I32,
    // I64,

    // U8,
    // U16,
    // U32,
    // U64,

    // Bool,
    True,
    False,

    // String,
    StringLiteral, // "

    NumberLiteral,

    Namespace,
    Import,        // for import stuff

    Comment,
    MultiLineComment,
    WhiteSpace,
    Eof,

}