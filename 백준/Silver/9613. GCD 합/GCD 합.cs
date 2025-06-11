
/*
    첫 줄에 테스트 케이스 수 T
    각 테스트 케이스는 정수 개수인 n과 n개의 수가 주어짐 ex) 4, 10, 20, 30, 40
    각 테스트 케이스마다 가능한 모든 정수의 쌍의 GCD를 구해 그 합을 출력
 */

using System.Text;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());

        var sb = new StringBuilder();

        for (int i = 0; i < t; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);

            int[] numbers = new int[n];
            for (int j = 0; j < n; j++)
            {
                numbers[j] = int.Parse(inputs[j + 1]);
            }

            long sum = 0;

            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    sum += GCD(numbers[j], numbers[k]);
                }
            }

            sb.AppendLine(sum.ToString());

        }
        
        Console.WriteLine(sb);
    }

    // 유클리드 알고리즘
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int tmp = b;
            b = a % b;
            a = tmp;
        }
        return a;
    }
}

/*
 n개의 정수의 범위가 1,000,000 이하 이므로 sum을 int로 선언 시 경계조건에서 실패 가능성이 있으므로
 long으로 선언하여 오버플로우를 방지해주는 것이 좋다
 
 int의 범위 = -2,147,483,648 ~ 2,147,483,647
 long의 범위 = -9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807
 
 위의 문제에서 가능한 최악의 시나리오
 n = 100일 때,
 각 쌍의 GCD가 1,000,000이상 이라면 -> 1,000,000 * 100c2 = 4,950,000,000 (int 범위에서 오버플로우 발생)
*/