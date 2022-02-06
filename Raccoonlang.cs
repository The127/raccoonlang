﻿using Raccoonlang.Utils;

namespace Raccoonlang;

using System;
using System.Timers;

using Tokenizing;
using Parsing;
using Parsing.AST;

class Raccoonlang
{
    static void Main(string[] args)
    {
        Timer t = new();
        Tokenizer tokenizer = new Tokenizer();

        t.Start();
        
        ITokenStream stream = tokenizer.Tokenize("test.rcn", File.ReadAllText("test.rcn"));
        
        t.Stop();
        Console.WriteLine($"Tokenizing took {t.Interval}ms.");
        
        t.Start();
        
        FileAstNode ast = Parser.Parse((TokenStream) stream);
        
        t.Stop();
        Console.WriteLine(ast.AutoToString());
        Console.WriteLine($"Parsing took {t.Interval}ms.");
    }
}
