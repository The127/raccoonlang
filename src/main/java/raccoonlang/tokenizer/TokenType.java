package raccoonlang.tokenizer;

public enum TokenType {

    OPEN_PAREN,     // (
    CLOSE_PAREN,    // )
    OPEN_CURLY,     // {
    CLOSE_CURLY,    // }
    OPEN_SQUARE,    // [
    CLOSE_SQUARE,   // ]

    DOT,            // .
    COMMA,          // ,
    SEMICOLON,      // ;
    COLON,          // :

    EQUALS,         // =
    PLUS_EQUALS,    // +=
    MINUS_EQUALS,   // -=
    TIMES_EQUALS,   // *=
    DIVISION_EQUALS,// /=
    MODULO_EQUALS,  // %=
    AND_EQUALS,     // &=
    OR_EQUALS,      // |=
    XOR_EQUALS,     // ^=

    OP_PLUS,        // +
    OP_MINUS,       // -
    OP_TIMES,       // *
    OP_DIVISION,    // /
    OP_MODULO,      // %
    OP_BIN_AND,     // &
    OP_BIN_OR,      // |
    OP_BOOL_AND,    // &&
    OP_BOOL_OR,     // ||
    OP_XOR,         // ^

    OP_LT,          // <
    OP_GT,          // >

    OVERLOAD_PLUS,
    OVERLOAD_MINUS,
    OVERLOAD_TIMES,
    OVERLOAD_DIVISION,
    OVERLOAD_MODULO,

    OP_NOT,         // !

    LAMBDA_ARROW,   // =>

    PUBLIC,
    PRIVATE,
    PROTECTED,
    INTERNAL,
    OVERRIDE, //TODO

    DATA,
    CLASS,
    INTERFACE,
    FN,
    IDENTIFIER,
    VAR,

    F64,
    F32,

    I8,
    I16,
    I32,
    I64,

    U8,
    U16,
    U32,
    U64,

    BOOL,
    TRUE,
    FALSE,

    STRING,
    STRING_LITERAL, // "

    NUMBER_LITERAL,

    NAMESPACE,
    IMPORT,        // for import stuff

    COMMENT,
    MULTI_LINE_COMMENT,
    WHITE_SPACE,
    EOF,

}

/*

namespace help.me;

public data class Point2d(f64 X, f64 Y){

    public new(Point2d other) : this(other._x, other._y);

    public Point2d operator+(Point2d other) => new(other.x + _x, other.y + _y);
    public Point2d operator*(f64 scalar) => Point2d.new(_x*scalar, _y*scalar);
}

public void main(){// optionally string[] args or smth
    var p = Point2d.new(1, 2) * 3;
    println(p);
}

 */
