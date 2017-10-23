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
        private Node _currentNode;
        
        public void push(int value)
        {
            var node = new Node(value, _currentNode);
            _currentNode = node;
        }
        
        public int pop()
        {
            int value = _currentNode.Value;
            _currentNode = _currentNode.PrevNode;
            return value;
        }
    }
    
    public class Node
    {
        public Node(int value, Node prevNode)
        {
            _value = value;
            _prevNode = prevNode;
        }
        
        private int _value;
        private Node _prevNode;
        
        public int Value {
            get {return _value;}
        }
        public Node PrevNode {
            get {return _prevNode;}
        } 
    }
}