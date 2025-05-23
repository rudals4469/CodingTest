using System;

/*
 입력 : 두 분수, numer1/denom1, numer2/denom2
 출력 : 두 분수의 합을 기약분수의 형태로 반환
 */
public class Solution {
    public int[] solution(int numer1, int denom1, int numer2, int denom2)
    {
        
        int commonDenom = denom1 * denom2; // 분모
        int SuperNumer = numer1 * denom2 + numer2 * denom1; // 분자

        // 기약 분수 만들어야 되잖아 -> 최대 공약수 구해서 최대 공약수로 나누기

        int gcd = GCD(SuperNumer, commonDenom);
        
        // 최대 공약수로 나누기
        int answerNumber = SuperNumer / gcd;
        int answerDenom = commonDenom / gcd;


        return new int[] { answerNumber, answerDenom };
    }

    // 유클리드 호제법
    private int GCD(int a, int b)
    {
        while (b != 0) // 2
        {
            int temp = b; // 2
            b = a % b; // 0 = 6 % 2
            a = temp; // a = 2 
        }
        // (ex) 8, 6
        // 1 : a = 2, b = 6
        // 2 : a = 6, b = 2
        // 3 : a = 2, b = 0
        // 4 : break
        
        return a;
    }
}