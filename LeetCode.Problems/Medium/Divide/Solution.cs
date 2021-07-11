namespace LeetCode.Problems.Medium.Divide
{
    /// <summary>
    /// https://leetcode.com/problems/divide-two-integers/
    /// </summary>
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == -2147483648 && divisor == -1) return 2147483647;
            long counter = 0;
            
            long dend = dividend;
            if (dividend < 0) dend = 0L - dividend;

            long sor = divisor;
            if (divisor < 0) sor = 0L - divisor;

            if (dend < sor) return 0;

            if (sor == 1)
            {
                counter = dend;
            }
            else
            {
                while (dend >= sor)
                {
                    long k = 1;
                    var tempSor = sor;
                    while (dend >= tempSor)
                    {
                        tempSor += tempSor;
                        k += k;
                    }

                    dend -= tempSor >> 1;
                    k >>= 1;
                    counter += k;
                }
            }

            if (dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0) return (int)(0 - counter);

            return (int)counter;
        }
    }
}