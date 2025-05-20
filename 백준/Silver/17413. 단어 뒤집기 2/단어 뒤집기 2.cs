using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        bool inTag = false;

        foreach (char c in input)
        {
            if (c == '<')
            {
                while (stack.Count > 0)
                    result.Append(stack.Pop());

                inTag = true;
                result.Append(c);
            }
            else if (c == '>')
            {
                inTag = false;
                result.Append(c);
            }
            else if (inTag)
            {
                result.Append(c);
            }
            else
            {
                if (c == ' ')
                {
                    while (stack.Count > 0)
                        result.Append(stack.Pop());
                    result.Append(' ');
                }
                else
                {
                    stack.Push(c);
                }
            }
        }

        while (stack.Count > 0)
            result.Append(stack.Pop());

        Console.WriteLine(result.ToString());
    }
}