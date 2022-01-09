package raccoonlang;

public class Main {

    public static void main(String[] args) {
        if (!ArgumentsParser.parseArguments(args)) {
            printUsage();
        }
    }

    public static void printUsage() {
        System.out.println("Usage: raccoon compile file.rcn");
    }

}
