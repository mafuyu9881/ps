// 0 ≤ N ≤ 500
// 팩토리얼을 구성하는 인수들 중 10이 몇 개가 있는지 파악하는 방법입니다.

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int factor_two_counts = 0;
        int factor_five_counts = 0;

        for (int i = 1; i <= n; ++i)
        {
            int factorial_factor = i;
            
            while (factorial_factor % 2 == 0)
            {
                factorial_factor /= 2;
                ++factor_two_counts;
            }

            while (factorial_factor % 5 == 0)
            {
                factorial_factor /= 5;
                ++factor_five_counts;
            }
        }

        Console.Write(Math.Min(factor_two_counts, factor_five_counts));
    }
}