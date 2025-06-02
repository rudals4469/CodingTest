using System.Text;

class Program
{
    // 입력 : 첫 줄에 수의 개수 N ( 1 <= N <= 100), 둘째 줄에 N개의 자연수 (각각 1<= 자연수 <= 1000)
    // 출력 : 소수의 개수 출력
    
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();

        int count = 0;

        foreach (string str in input )
        {
            int num = int.Parse(str);
            if (IsPrime(num))
                count++;
        }
        
        Console.WriteLine(count);
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}