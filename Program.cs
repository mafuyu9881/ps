// 동적 계획법을 통한 구현 (Memoization, top-down)
internal class Program
{
    private static int?[,] binomial_coefficients = new int?[0, 0];

    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        binomial_coefficients = new int?[n + 1, n + 1];

        Console.Write(binomial_coefficient(n, k));
    }

    private static int binomial_coefficient(int times, int left)
    {
        if (left < 0)
            return 0;

        if (times == 0)
            return Convert.ToInt32(left == 0);

        int? memoized_binomial_coefficient = binomial_coefficients[times, left];
        if (memoized_binomial_coefficient != null)
            return memoized_binomial_coefficient.Value;

        int prev_times = times - 1;
        int prev_left = left - 1;
        binomial_coefficients[times, left] = binomial_coefficient(prev_times, left) + binomial_coefficient(prev_times, prev_left);
        return binomial_coefficients[times, left]!.Value;
    }
}