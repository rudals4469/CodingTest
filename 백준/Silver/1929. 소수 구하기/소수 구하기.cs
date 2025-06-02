using System.Text;

class Program
{
    // 입력 : 두 정수 M,N
    // 출력 : M 이상 N 이하의 소수를 한 줄에 하나씩 출력
    
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        bool[] isPrime = new bool[n + 1];

        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j+=i)
                {
                    isPrime[j] = false;
                }
            }
        }

        for (int i = m; i <= n; i++)
        {
            if(isPrime[i])
                Console.WriteLine(i);
        }
    }
}