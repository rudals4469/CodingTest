using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int count = 0;

        // n!에서 뒤에 붙는 0의 개수를 구하기 위해
        // 5, 25, 125, ... 로 나누면서 5의 개수를 누적
        while (n >= 5)
        {
            count += n / 5; // n 안에 있는 5의 배수 개수를 더함
            n /= 5;          // 다음엔 25의 배수 개수를 더하기 위해 n을 5로 나눔
        }

        Console.WriteLine(count);
    }
}

/*
    n!에서 0이 생기는 원인은 10 = 2 × 5
    그런데 n!에는 2는 항상 5보다 많이 포함되므로, 5의 개수만 세면 됨
    구체적으로는 n / 5, n / 25, n / 125 ... 등을 모두 더하면 됨
    = 사실상 팩토리얼 계산을 안하고 입력 받은 숫자에 5개 갯수를 체크하면 됨
 */