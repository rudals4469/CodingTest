using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Factorial(n));
    }

    static int Factorial(int n)
    {
        if (n <= 1)
            return 1;

        return n * Factorial(n - 1);
    }
}

/*
    Factorial 함수는 재귀를 이용해서 n!을 계산
    입력값이 0이거나 1이면 결과는 1
    그 외의 경우 n * Factorial(n - 1)을 반환
 */