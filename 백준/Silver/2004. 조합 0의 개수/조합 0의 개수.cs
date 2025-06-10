using System;

/*
 앞의 팩토리얼 문제와 팩토리얼 0의 개수 문제의 응용 문제
 */

class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        // nCm = n! / (m! * (n - m)!)
        // 2와 5의 개수를 각각 구해서 그 중 작은 값을 출력

        int countTwo = CountFactor(n, 2) - CountFactor(m, 2) - CountFactor(n - m, 2);
        int countFive = CountFactor(n, 5) - CountFactor(m, 5) - CountFactor(n - m, 5);

        // 2와 5의 짝이 10이 되므로 둘 중 작은 값을 선택
        Console.WriteLine(Math.Min(countTwo, countFive));
    }

    // 주어진 수 n까지의 팩토리얼 안에 포함된 인수 `factor`(예: 2 또는 5)의 총 개수 세기
    static int CountFactor(int n, int factor)
    {
        int count = 0;
        while (n >= factor)
        {
            count += n / factor;
            n /= factor;
        }
        return count;
    }
}

/*
    부분	            의미
    n!	            전체 곱셈, 가장 많은 2와 5
    m!, (n - m)!	분모 → 제거해줘야 할 2와 5
    - 연산	        조합 식의 나눗셈 구조 때문
    min(2, 5)	    10의 개수 = 0의 개수
*/