public class Solution {
    public int solution(int a, int b) {
        bool aOdd = a % 2 == 1;
        bool bOdd = b % 2 == 1;

        if (aOdd && bOdd)
            return a * a + b * b;
        else if (aOdd || bOdd)
            return 2 * (a + b);
        else
            return System.Math.Abs(a - b);
    }
}
