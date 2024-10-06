using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        BigInteger a = BigInteger.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);
        int c = int.Parse(tokens[2]);

        // exponentiation by squaring
        BigInteger output = 1;
        while (b > 0)
        {
            // 짝수의 경우, 마지막 비트는 항상 0이다.
            // 홀수의 경우, 마지막 비트는 항상 1이다.
            if ((b & 1) == 1)
            {
                // 지수가 홀수일 때 남은 1을 처리하기 위한 것이다.
                output *= a;
                output %= c;
            }

            // 밑을 제곱, 지수를 반으로 줄이기 위한 과정이다.
            a *= a;
            a %= c;

            // 위의 계산에 의거하여 지수를 반으로 줄인다.
            b >>= 1;
        }
        Console.Write(output);
    }
}