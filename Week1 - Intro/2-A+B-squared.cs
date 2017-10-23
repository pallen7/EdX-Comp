using System.IO;
using System;

public class Program
{
    private static void Main()
    {
        TextReader textReader;
        TextWriter textWriter;
#if JUDGE
        textReader = new StreamReader("input.txt");
#else
        textReader = Console.In;
#endif


        var input = textReader.ReadLine().Split(' ');
        textReader.Close();
        
        var b = Int64.Parse(input[1]);
        
        var answer = int.Parse(input[0]) + b*b;

        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        
        textWriter.WriteLine(answer);
        textWriter.Close();
    }
}