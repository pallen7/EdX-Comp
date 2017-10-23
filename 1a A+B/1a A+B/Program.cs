﻿#define JUDGE

using System;
using System.IO;

namespace _1a_A_B
{
    public class Program
    {
        private static void Main()
        {
            TextReader input;

#if JUDGE
            input = new StreamReader("input.txt");
#else
            input = Console.In;
#endif

            string[] numbers = input.ReadLine().Split(' ');
            input.Close();

            int answer = int.Parse(numbers[0]) + int.Parse(numbers[1]);

            TextWriter output;

#if JUDGE
            output = new StreamWriter("output.txt");
#else
            output = Console.Out;
#endif

            output.WriteLine(answer);
            output.Close();
#if (!JUDGE)
            Console.ReadLine();
#endif
        }
    }
}
