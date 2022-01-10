package raccoonlang;

import raccoonlang.tokenizer.TokenStream;
import raccoonlang.tokenizer.TokenType;
import raccoonlang.tokenizer.Tokenizer;

public class Main {

    public static void main(String[] args) {
        Tokenizer testee = new Tokenizer();
        TokenStream stream = testee.tokenize("fake", "" +
                "//namespace help.me;\n" +
                "\n" +
                "public data class Point2d(f64 X, f64 Y){\n" +
                "\n" +
                "    public new(Point2d other) : this(other._x, other._y);\n" +
                "\n" +
                "    public Point2d operator+(Point2d other) => new(other.x + _x, other.y + _y);\n" +
                "    public Point2d operator*(f64 scalar) => Point2d.new(_x*scalar, _y*scalar);\n" +
                "}\n" +
                "\n" +
                "public void main(){// optionally string[] args or smth\n" +
                "    var p = Point2d.new(1, 2) * 3;\n" +
                "    println(p);\n" +
                "}");
        System.out.println("token count: " + stream.size());
        for(int i = 0; i < stream.size()+1; i++){
            System.out.println(stream.take());
        }
        if (!ArgumentsParser.parseArguments(args)) {
            printUsage();
        }
    }

    public static void printUsage() {
        System.out.println("Usage: raccoon compile file.rcn");
    }

}
