using System;
using System.Collections.Generic;

class Program
{
     /*
     입력 : 수열 A: N개의 자연수 (1 ≤ Ai ≤ 1,000,000)
     출력 : 각 Ai에 대해 오등큰수를 출력 -> 오등큰수란 오른쪽에 있으면서 등장 횟수가 Ai보다 많은 수 중 가장 왼쪽에 있는 수
     
     -> 오큰수 에서 조건만 큰 숫자를 찾는게 아니라 가장 많이 나온 걸 찾으면 되겠구만
     */
     
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] answer = new int[n];
        Stack<int> stack = new Stack<int>();
        
        int[] freq = new int[1000001]; 
        
        // 등장 횟수 세기
        for (int i = 0; i < n; i++)
            freq[arr[i]]++;

        // 오등큰수 찾기
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && freq[arr[stack.Peek()]] < freq[arr[i]]) // arr[i]가 stack.Peek()보다 등장 횟수가 더 많으면 오등큰수를 찾은 것
            {
                int idx = stack.Pop();
                answer[idx] = arr[i];
            }
            stack.Push(i);
        }

        // 오등큰수 없는 경우 -1
        while (stack.Count > 0)
            answer[stack.Pop()] = -1;
        
        /*
         
        7
        1 1 2 3 4 2 1
        
        freq[1] = 3
        freq[2] = 2
        freq[3] = 1
        freq[4] = 1
        
        i = 0, arr[0] = 1 -> stack = [0]
        
        i = 1, arr[1] = 1 -> freq[1] < freq[1] (x) -> stack = [0, 1] -> answer = [null, null, null, null, null, null, null]
        
        i = 2, arr[2] = 2 -> freq[1] < freq[2] (x) -> stack = [0, 1, 2] -> answer = [null, null, null, null, null, null, null]
        
        i = 3, arr[3] = 3 -> freq[2] < freq[3] (x) -> stack = [0, 1, 2, 3] -> answer = [null, null, null, null, null, null, null]
        
        i = 4, arr[4] = 4 -> freq[3] < freq[4] (x) -> stack = [0, 1, 2, 3, 4] -> answer = [null, null, null, null, null, null, null] 
        
        i = 5, arr[5] = 2 -> freq[4] < freq[2] (o) -> Pop(4) -> stack = [0, 1, 2, 3] -> answer = [null, null, null, 2, null, null, null]
                          -> freq[3] < freq[2] (o) -> Pop(3) -> stack = [0, 1, 2] -> answer = [null, null, null, 2, 2, null, null]
                          -> freq[2] < freq[2] (x) -> stack = [0, 1, 2, 5] ->  answer = [null, null, null, 2, 2, null, null]
                          
        i = 6, arr[6] = 1 -> freq[2] < freq[1] (o) -> Pop(5) -> stack = [0, 1, 2] ->  answer = [null, null, null, 2, 2, 1, null]
                          -> freq[2] < freq[1] (o) -> Pop(2) -> stack = [0, 1] -> answer = [null, null, 1, 2, 2, 1, null]
                          -> freq[2] < freq[2] (x) -> stack = [0, 1, 6] ->  answer = [null, null, 1, 2, 2, 1, null]
        
        stack.Count = 0이 될때 까지 Pop(n) 하고 그 수를 -1로 대입 ->  answer = [-1, -1, 1, 2, 2, 1, 1]
        
         */

        Console.WriteLine(string.Join(" ", answer));
    }
}