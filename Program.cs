// 0 ≤ N ≤ 500
// N!의 최대는 1.220136825991110068701238785423e+1134로, 대충 11__자리 정도 되어보인다.
// 2byte * 1200 = 2400byte = 2.4 kilobyte
// 메모리 제한이 128MB이므로 문자열로 풀어도 문제없을 것으로 보인다.

using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine()!);
        
        BigInteger n_factorial = 1;
        for (BigInteger i = 1; i <= n; ++i)
        {
            n_factorial *= i;
        }

        string n_factorial_string = n_factorial.ToString();

        int output = 0;
        for (int i = n_factorial_string.Length - 1; i > -1; --i)
        {
            if (n_factorial_string[i] != '0')
                break;
            
            ++output;
        }

        Console.Write(output);
    }
}