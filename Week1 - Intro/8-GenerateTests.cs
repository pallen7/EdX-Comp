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


        var input = int.Parse(textReader.ReadLine());
        textReader.Close();
		
		// Define a set of numbers that we want to test
		// Need to calculate:
		// -> Start
		// -> Gap
		var start = CalculateStart(input);
		
		var maxDivisors=1;
		var mostDivisible=1;
		
		for (int i=start; i<=input; i+=start)
		{
			int result = DivisorCount(i);
			
			if (result > maxDivisors)
			{
				maxDivisors=result;
				mostDivisible=i;
				Console.WriteLine("maxDivisors:" + maxDivisors);
				Console.WriteLine("mostDivisible:" + mostDivisible);
			}
			
			// Console.WriteLine("i=" + i + ". result=" + result);
		}
		
		// Find out how many divisors a number has
		
		var divisors = DivisorCount(input);
		
        Console.WriteLine("Start:" + start);
        Console.WriteLine("Divisors:" + divisors);
		
		
		var answer = (input - mostDivisible) + 1;

        
#if JUDGE
        textWriter = new StreamWriter("output.txt");
#else        
        textWriter = Console.Out;
#endif
        
        textWriter.WriteLine(answer);
        textWriter.Close();
    }
	
	
	
	private static int CalculateStart(int value)
	{
		
		//if (value < 50) return 1;
		
		var primes = new int[] {1,2,3,5,7,11,13,19,23};
		var i=0;
		var result=1;
		
		do
		{
			i++;
			result *= primes[i];
			
		} while(value >= result);
		
		result = 1;
		
		for(int j=0; j<(i-1); j++)
		{
			result *= primes[j];
		}
		
		return result;
	}
	
	private static int DivisorCount(int number)
	{
		// Workaround
		if (number == 1) return 1;
		
		int result=1;
		int maxLoop = number/2;
		
		for (int i=2; i<=maxLoop; i++)
		{
			if (number % i == 0) result ++;
		}
		
		return result+1;
	}
}
