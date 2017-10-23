using System.IO;
using System;

/*
Do you know that the way you sit during a programming competition may have an impact on your results? In particular, location of chairs related to tables and the computer can strongly inﬂuence the relationships in your team.

The famous team of three, called Dream Team, is going to participate in a competition called NIRC. According to the regulations of this competition, every team is given a single computer, which is located on a triangular table, and three chairs.

Dream Team thinks that the most convenient location of participants is the one where each of the three participants sits at his/her own side of the triangular table, and, what's important, exactly at the middle of this side. Of course, chairs should be put the same way.

It is important that, during the competition, the participants sit not very far one from another. The Dream Team's captain thinks that a proper estimation of this factor is an average distance between all the pairs of these participants.

In the case of the NIRC competition, one have to compute an average distance between the middle points of the sides of a triangular table. Write a program which computes exactly this. Note that the distance is Euclidean – that is, the distance between (x1,y1) and (x2,y2) is srt(x1−x2)2+(y1−y2)2.

Input
The input file contains three positive integer numbers not exceeding 100 – the lengths of sides of the table. It is guaranteed that such a table will have a non-zero area.

Output
Output the average distance between the middle points of the sides of the table, which was described in the input. Any answer, which differs from the correct one by not more than 10−6, will be accepted.

Examples
input.txt
output.txt
3 4 5	2.00000000
5 5 7	2.83333333

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


        var input = textReader.ReadLine().Split(' ');
        textReader.Close();
        
        var a = int.Parse(input[0]);
        var b = int.Parse(input[1]);
        var c = int.Parse(input[2]);
        
        var answer = ((a+b+c)/6.0);
        
        // Have to work out the points of the triangle to start

        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        
        textWriter.WriteLine(answer);
        textWriter.Close();
    }
}