package raccoonlang;

public class ArgumentsParser {

    public static boolean parseArguments(String[] args) {
        if (args.length < 1) {
            return false;
        }

        switch (args[0]) {
            case "compile"-> {
                System.out.println("Compile Time!");
            }
            case "help" -> {
                return false;
            }
            default -> {
                System.err.println("Option not recognized!");
                return false;
            }
        }

        return true;
    }

}
