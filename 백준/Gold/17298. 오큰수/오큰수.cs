using System;


/*
 입력 : 정수 N (1 ≤ N ≤ 1,000,000) 과 수열 A1, A2, ..., AN
 출력 : 각 Ai에 대해 오큰수(자기 오른쪽에 있으면서 자신보다 큰 수 중 가장 왼쪽에 있는 수)를 출력. 없다면 -1
 */
/*
 
 */
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] answer = new int[n];
        Stack<int> stack = new Stack<int>();

        // 배열 [3, 5, 2, 7]
        
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
            {
                int idx = stack.Pop();
                answer[idx] = arr[i];
            }
            stack.Push(i);
        }
        
        /*
         i = 0 일 때, arr[i] = 3, stack = [0], answer = [null, null, null, null]
         i = 1 일 때, arr[i] = 5, stack = [1], answer = [5, null, null, null]
         i = 2 일 때, arr[i] = 2, stack = [1, 2], answer = [5, null, null, null]
         i = 3 일 때, arr[i] = 7, stack = [3], answer = [5, 7, 7, null]
         */
        
        while (stack.Count > 0)
        {
            answer[stack.Pop()] = -1;
        }

        Console.WriteLine(string.Join(" ", answer));

        
    }
    void tset()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] answer = new int[n];

        for (int i = 0; i < n; i++)
        {
            answer[i] = -1; // 기본값 -1
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] > arr[i])
                {
                    answer[i] = arr[j];
                    break; // 가장 왼쪽 큰 수 찾으면 탈출
                }
            }
        }

        Console.WriteLine(string.Join(" ", answer));
    }
}