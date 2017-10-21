using System.IO;
using System;

/*
To successfully participate in programming competitions, you should prepare a lot. This is very clear to young Jamie. So he decided to undertake a scientific point of view. Jamie thinks that the preparation level is determined by a certain number, the ability to solve problems, which accumulates every possible aspect of being ready to compete well.

After reading some books on competitive programming, Jamie understood that there are two ways to improve his skills: studying theory and practicing a lot. There are n days before the next programming competition. Based on his biorhythm calendar, Jamie determined two numbers for each of these days: ti is how much his ability to solve problems will improve if he studies theory at the i-th day, and pi is how much it will improve if he practices a lot at the i-th day. Every day should be entirely dedicated to either theory or practice. Additionally, at least one of these days should be theoretical, and at least one should be practical.

Help Jamie construct such a timetable which increases his ability to solve problems to a maximum possible value. You may assume that this value is equal to zero before preparation.

Input
The first line of the input file contains an integer n (2≤n≤100). The second line contains n integers p1,p2,…,pn, separated by whitespace. The third line contains n integers t1,t2,…,tn, separated by whitespace.

All pi and ti are positive and do not exceed 1000.

Output
Output the maximum possible value of ability to solve problems, which Jamie can achieve in n days. Pay attention to the fact that Jamie should spend at least one day for theory, and at least one day for practicing.

Examples
input.txt
output.txt
2
1 2
2 1	    = 4

3
1 2 3
1 2 3   = 6

*/

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

        var days = int.Parse(textReader.ReadLine());
        var pScores = textReader.ReadLine().Split(' ');
        var tScores = textReader.ReadLine().Split(' ');
        textReader.Close();
        
        // workout a theory day based on the biggest gap where t >= p
        // workout a practical day based on the biggest gap where p >= t
        // rest of the days take the largest number
        
        int total=0, pScore=0, tScore=0, tCount=0, pCount=0, minGap=999;
        
        for (int i=0; i<days; i++)
        {
            pScore = int.Parse(pScores[i]);
            tScore = int.Parse(tScores[i]);
            
            if (tScore > pScore) tCount ++;
            if (pScore > tScore) pCount ++;
            if (Math.Abs(tScore - pScore) < minGap) minGap = Math.Abs(tScore - pScore);
            total += pScore > tScore ? pScore : tScore;
        }
        
        var answer = (tCount==0 || pCount==0) ? total-minGap : total;

        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        
        textWriter.WriteLine(answer);
        textWriter.Close();
    }
}