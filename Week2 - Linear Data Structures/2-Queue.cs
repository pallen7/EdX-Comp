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
        textWriter = new StreamWriter("output.txt");
#else
        textReader = Console.In;
        textWriter = Console.Out;
#endif

        var stack = new Stack();

        int rows = int.Parse(textReader.ReadLine());
        for (int i=0; i<rows; i++)
        {
            var input = textReader.ReadLine().Split(' ');
            
            if (input[0] == "+")
            {
                stack.push(int.Parse(input[1]));
            }
            else
            {
                textWriter.WriteLine(stack.pop());
            }
        }
        
        textReader.Close();
        textWriter.Close();
        
    }
    
    public class Stack
    {
        private Node _firstNode;
		private Node _lastNode;
        
        public void push(int value)
        {
            var node = new Node(value);
			if (_firstNode != null)
			{
				_lastNode.NextNode = node;
				_lastNode = node;
			}
			else 
			{
				_firstNode = node;
				_lastNode = node;
			}
        }
        
        public int pop()
        {
            int value = _firstNode.Value;
			_firstNode = _firstNode.NextNode;
            return value;
        }
    }
    
    public class Node
    {
        public Node(int value)
        {
            _value = value;
        }
        
        private int _value;
        private Node _nextNode;
        
        public int Value {
            get {return _value;}
        }
        public Node NextNode {
            get {return _nextNode;}
			set {_nextNode = value;}
        } 
    }
}