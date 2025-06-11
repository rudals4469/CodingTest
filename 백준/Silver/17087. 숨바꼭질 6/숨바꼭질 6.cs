
/*
 1번 째 줄, 동생의 명수 = N, 수빈이의 현재 위치 S
 2번 째 줄, 동생들의 위치
 
 출력 : 가장 큰 D (D = 수빈이가 한 번에 움직일 수 있는 거리)
 
 기본 원리 : 수빈이의 현재 위치에서 동생들의 위치를 뺀 값의 최대공약약수를 구하면 됨
 */
class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int s = int.Parse(firstLine[1]);

        string[] secondLine = Console.ReadLine().Split();
        int[] distances = new int[n];

        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(secondLine[i]);
            distances[i] = Math.Abs(a - s);  // 거리 차이 절댓값 (유클리드 알고리즘을 위해서는 두 수가 모두 양수여야 하기 때문)
        }

        int result = distances[0];
        
        for (int i = 1; i < n; i++)
        {
            result = GCD(result, distances[i]);  // 누적 GCD 
        }

        Console.WriteLine(result);
    }

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
        1. 
        distances[i] = Math.Abs(a - s);
        
        이 구문에서 절댓값을 씌우는 이유는 정확하겐 GCD는 음수를 받아와도 제대로 된 값은 나오지만
        최대공약수의 개념은 양의 정수에서 정의되기 떄문에 음수를 고려하지 않는 것이 일반적인 수학적 관례라고 한다.
         
        2. 
         for (int i = 1; i < n; i++)
        {
            result = GCD(result, distances[i]);  // 누적 GCD 
        }
        
        이 구문이 누적 GCD가 되는 이유 : 여러 수 의 GCD는 두 수씩 순서대로 GCD를 계산해도 동일하게 나온다.
        ex) GCD(a, b, c, d) == GCD(GCD(GCD(a, b), c), d)
        
        그렇기 때문에
        
        result = GCD(result, distances[1]);
        result = GCD(result, distances[2]);
        result = GCD(result, distances[3]);
        ...
        
        와 같이 계속 반복문이 돌 수록 누적된 GCD를 구할 수 있게 된다.
        

 */