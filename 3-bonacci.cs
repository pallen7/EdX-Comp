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
    
        // 1(T0) 2(T1) 3(T2) N=4: 
        // # (2 + 3) - 1 = 4 (N=3)
        // # (4 + 3) - 2 = 5 (N=4)
        // 1 2 3 5:
        // # (2 + 3) - 1 = 4 (N=3)
        // # (4 + 3) - 2 = 5 (N=4)
        // # (5 + 4) - 3 = 6 (N=5)
        
        // if N=0 then T0
        // if N=1 then T1
        // if N=2 then T2
        
        
        var t0 = int.Parse(input[0]);
        var t1 = int.Parse(input[1]);
        var t2 = int.Parse(input[2]);
        var n = int.Parse(input[3]);
        
        int a=t0, b=t1, c=t2, answer=0;
        
        if (n == 0) {answer = t0;}
        if (n == 1) {answer = t1;}
        if (n == 2) {answer = t2;}
        
        if (n > 2)
        {
            for (int i=3; i<=n; i++)
            {
                answer = c+b-a;
                a=b;
                b=c;
                c=answer;
            }
        }
        
        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        
        textWriter.WriteLine(answer);
        textWriter.Close();
    }
}