using System.IO;
using System;

/*
In a programming competition, most solutions have to perform similar actions, such as opening and closing input and output files. Everyone who participated in competitions encountered this situation and, as a result, invented a code template for personal use.

A code template is a program, which serves as the starting point for writing the actual solution to a programming problem. Being a template, it is typically written once for all solutions at the beginning of the competition.

However, there is a problem. Everyone has her/his own favourite language for programming competitions, and of course the code template is prepared for this language as well.

Alice, Beatrice and Cynthia are forming a team, and now they have to agree on which programming language to choose. After long discussions, they decided to choose a language, for which they have a code template which takes the minimum time to type.

Assume that the keyboard, which is used in the competition, is rectangular, and every symbol presents at most once on this keyboard. Let's introduce a Cartesian coordinate system, such that the coordinates of all keys are integers. What's more, all x values belong to the [1;W] range, all y values belong to the [1;H] range, and the lower left key has the coordinate of (1;1).

The distance between the two symbols on this keyboard is the maximum of the differences of key coordinates where these two symbols are located. For instance, if symbol A has a key with coordinates (XA,YA), and symbol B has a key at (XB,YB), then the distance between A and B is max(|XA−XB|,|YA−YB|).

The time to type a code template is the sum of distances between the first and the second symbol, the second and the third symbol, …, the next-to-last and the last symbol of the template. Whitespaces of all sorts and newline characters are not counted as symbols of the template.

Alice, Beatrice and Cynthia each proposed her own template for her favourite programming language. Please help them to choose the optimal ones!

Input
The first line of the input ﬁle contains two integer numbers W and H (1≤W,H≤94) – the width and the height of the keyboard. The next H lines contain W ASCII symbols each with possible codes from 33 to 126 inclusively. These lines determine the keyboard. Each symbol occurs at most once.

After this, three blocks follow, each containing a code template description. The first line of each block is the name of the programming language. The name of the programming language does not exceed 100 characters and may contain ASCII symbols from 33 to 126. The next line contains a string %TEMPLATE-START%. The following lines contain the code template itself. In every line, the allowed symbols are ASCII symbols from 32 to 126, however, whitespaces (ASCII code 32) should be ignored. The code template never contains a string %TEMPLATE-END%. In the line following the last line of the code template there is a string %TEMPLATE-END%.

The number of symbols in every code template does not exceed 10000 (not including newline characters). Every symbol in a template will exist on the keyboard (which was described in the beginning of the input file).

Output
In the first line of the output file print the name of the language of the code template, which the team should choose. The second line should contain the time needed to type the chosen code template. If there are several possible code templates with the same time, output the one which comes first in the input file.

Examples
input.txt
3 1
abc
LanguageA
%TEMPLATE-START%
a
%TEMPLATE-END%
LanguageAB
%TEMPLATE-START%
ab
%TEMPLATE-END%
LanguageB
%TEMPLATE-START%
b
%TEMPLATE-END%
output.txt
LanguageA
0
input.txt
10 9
1234567890
!@#$%^&*()
qwertyuiop
QWERTYUIOP
asdfghjkl;
ASDFGHJKL:
zxcvbnm,./
ZXCVBNM<>?
[]{}='"-|+
Pascal
%TEMPLATE-START%
begin
  reset(input, 'filename.in');
  rewrite(output, 'filename.out');
end.
%TEMPLATE-END%
C
%TEMPLATE-START%
int main()
{
    freopen("filename.in", "r", stdin);
    freopen("filename.out", "w", stdout);
}
%TEMPLATE-END%
Java
%TEMPLATE-START%
import mooc.*;
public class Main {
    public static void main(String[] args) {
        try (EdxIO io = EdxIO.create()) {
        }
    }
}
%TEMPLATE-END%
output.txt
Pascal
240
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

        var inArr = textReader.ReadLine().Split(' ');
        var inWidth = int.Parse(inArr[0]);
        var inHeight = int.Parse(inArr[1]);
        
        string inStr;
        string[] titles = new string[3];
        string[] codes = new string[3];
        int[] scores = new int[3];
        char[,] keys = new char[inWidth,inHeight];
        
        for(int i=0; i<inHeight; i++)
        {
            inStr = textReader.ReadLine();
            
            for(int j=0; j<inWidth; j++)
            {
                keys[j,i] = inStr[j];
            }
        }
        
        int prevX=0;
        int prevY=0;
        
        for (int i=0;i<3;i++)
        {
            titles[i] = textReader.ReadLine();
            textReader.ReadLine(); // TEMPLATE-START
            inStr = textReader.ReadLine().Replace(" ","");
            do
            {   
                codes[i] += inStr;
                inStr = textReader.ReadLine().Replace(" ","");
            } while(inStr != "%TEMPLATE-END%");
            
            scores[i]=0;
            
            for (int j=0; j<codes[i].Length; j++)
            {
                int keyIdx = findKey(codes[i][j], keys, inHeight, inWidth);
                int currX = keyIdx%inWidth;
                int currY = keyIdx/inWidth+1;
                currY = currX == 0 ? currY-1 : currY;
                currX = currX == 0 ? inWidth : currX;
                int score = 0;
                
                if (j > 0)
                {
                    int scoreX = Math.Abs(currX - prevX);
                    int scoreY = Math.Abs(currY - prevY);
                    score = scoreX > scoreY ? scoreX : scoreY;
                }
                //Console.WriteLine(score.ToString() + " " + codes[i][j] + " " + keyIdx.ToString() + " " + currX.ToString() + " " + currY.ToString());
                scores[i] += score;
                prevX = currX;
                prevY = currY;
            }
        }
        
        int winner = 0;
        if (scores[1] < scores[winner]) winner = 1;
        if (scores[2] < scores[winner]) winner = 2;
        
        textReader.Close();

        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        textWriter.WriteLine(titles[winner]);
        textWriter.WriteLine(scores[winner]);
        textWriter.Close();
    }
    
    private static int findKey(char inKey, char[,] keys, int keysH, int keysW)
    {
        for(int h=0; h<keysH; h++)
        {
            for(int w=0; w<keysW; w++)
            {
                if (inKey == keys[w,h])
                {
                    return (w+1)+(keysW*h);
                }
            }
        }
        throw new System.Exception("Something has gone wrong");
    }
}