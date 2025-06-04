using System;
using System.Text;

class Program
{
    // 입력 :  각 테스트 케이스는 짝수 정수 n 하나로 이루어져 있다. (6 ≤ n ≤ 1000000) 입력은 하나 또는 그 이상의 테스트 케이스로 이루어져 있다. 입력의 마지막 줄에는 0이 하나 주어진다.
    // 출력 :  각 테스트 케이스에 대해서, n = a + b 형태로 출력한다. 이때, a와 b는 홀수 소수이다. 또, 두 홀수 소수의 합으로 n을 나타낼 수 없는 경우에는 "Goldbach's conjecture is wrong."을 출력한다.
    const int Max = 1000000;
    private static bool[] _isNotPrime = new bool[Max + 1];
    
    static void Main()
    {
        // 일단 먼저 소수를 구하는 함수(에라토스테네스의 체)
        Test(); 

        string input;
        StringBuilder sb = new StringBuilder(); // ← 명시적으로 수정

        while ((input = Console.ReadLine()) != null)
        {
            int n = int.Parse(input);

            if (n == 0) // 0 입력 시 종료
                break;
            
            // 소수의 합으로 나타내는 로직
            
            // 일단 먼저 나타낼 수 없는 경우의 수 부터
            bool found = false;

            // 짝수 n이 들어오면 3 부터 a 까지 소수를 탐색하고 n - a 도 소수인 지 판별 해서 확인.

            for (int i = 3; i <= n / 2; i += 2) 
            {
                if (!_isNotPrime[i] && !_isNotPrime[n - i])
                {

                    sb.AppendLine($"{n} = {i} + {n - i}");
                    found = true;

                    break; // n - a 가 가장 큰 거만 출력 = i가 제일 적은 거 = 제일 빨리 판별 한 거, 즉 먼저 찾은게 제일 클 꺼니깐 찾고 바로 여기 안들어오면 되지 않나

                }
            }

            if (!found)
            {
                sb.AppendLine("Goldbach's conjecture is wrong.");
            }

        }
        
        Console.Write(sb.ToString());
    }

    static void Test() // 에라토스테네스의 체
    {
        _isNotPrime[0] = _isNotPrime[1] = true; // 0이랑 1은 소수가 아님.

        for (int i = 2; i * i <= Max; i++)
        {
            if (!_isNotPrime[i])
            {
                for (int j = i * i; j <= Max; j += i)
                {
                    _isNotPrime[j] = true;
                }
            }
        }
    }
}
/*
        최악의 경우
        만약 n = 1000000인데 3 + 999997이 유일한 해라면, i가 999997 까지 모두 검사하게 됨.
        여기서 for 구문의 조건을 for(int i = 3; i<= n; i++) 에서 for(int i = 3; i<= n/2; i+=2) 로 바꾼다면
        시간복잡도가 O(n)이 아닌 O(n/2)로 줄어들어 크게 의미가 있음
        
        또한 중복 탐색할 필요도 없음 => 문제에서 [만약, n을 만들 수 있는 방법이 여러 가지라면, b-a가 가장 큰 것을 출력한다.] 라고 명시를 해줬기 때문에
         (i, n-i)와 (n-i, i)를 둘 다 검사할 필요가 없음
         
         => 나는 break 문 이 있으니 최적의 해를 찾은 순간 반복문을 그만 돈니깐 크게 성능에 문제가 없다고 생각했는데 최악의 경우를 생각하지 못했음.
         => 계속 시간 초과 나서 스트링 빌더로 일단 바꿔봄.     
*/
