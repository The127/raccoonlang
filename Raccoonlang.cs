﻿using System.Diagnostics;
using LLVMSharp;
using Raccoonlang.Utils;

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
        Stopwatch stopwatch = new Stopwatch();
        Tokenizer tokenizer = new Tokenizer();

        stopwatch.Start();

        var filePath = "./Samples/simple.rcn";
        ITokenStream stream = tokenizer.Tokenize(filePath, File.ReadAllText(filePath));
        
        stopwatch.Stop();
        Console.WriteLine($"Tokenizing took {stopwatch.ElapsedMilliseconds}ms.");
        
        stopwatch.Start();
        
        FileAstNode ast = Parser.Parse((TokenStream) stream);

        
        stopwatch.Stop();
        //Console.WriteLine(ast.AutoToString());
        Console.WriteLine($"Parsing took {stopwatch.ElapsedMilliseconds}ms.");

        var context = new LLVMContextRef();
        var builder = new IRBuilder(context);

        ast.Compile(context, builder);
    }
}
