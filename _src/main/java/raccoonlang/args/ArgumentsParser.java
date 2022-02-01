package raccoonlang.args;

import raccoonlang.tokenizer.Tokenizer;

import java.nio.file.Files;
import java.nio.file.Path;

public class ArgumentsParser {

    public static boolean parseArguments(String[] args) {
        if (args.length < 1) {
            return false;
        }

        switch (args[0]) {
            case "compile"-> {
                System.out.println("Compile Time!");
                Tokenizer tokenizer= new Tokenizer();
                if (args.length > 1) {
                    try {
                        String filePath = args[1];
                        tokenizer.tokenize(filePath, Files.readString(Path.of(filePath)));
                    } catch (Exception e ) {
                        e.printStackTrace();
                    }
                }
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
