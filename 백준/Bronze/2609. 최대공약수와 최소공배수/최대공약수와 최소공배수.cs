using System;
using System.Text;

class Program
{
    
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);

        int gcd = GCD(a, b);
        int lcm = a * b / gcd;

        Console.WriteLine(gcd);
        Console.WriteLine(lcm);
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