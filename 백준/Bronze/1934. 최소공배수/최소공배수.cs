using System;
using System.Text;

class Program
{
    
    static void Main()
    {
        var sb = new StringBuilder();
        int T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            int gcd = GCD(a, b);
            int lcm = a * b / gcd;

            sb.AppendLine(lcm.ToString());
        }
        
        Console.WriteLine(sb.ToString());
    }

    static int GCD(int x, int y)
    {
        while (y!=0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }

        return x;
    }
}