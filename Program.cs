// 동적 계획법을 통한 구현 (Memoization, bottom-up)
internal class Program
{
    private static int?[,] binomial_coefficients = new int?[0, 0];
    private static int n;
    private static int k;

    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        n = int.Parse(tokens[0]);
        k = int.Parse(tokens[1]);

        binomial_coefficients = new int?[n + 1, n + 1];

        Console.Write(binomial_coefficient(0, 0));
    }

    private static int binomial_coefficient(int times, int got)
    {
        if (times == n)
            return Convert.ToInt32(got == k);

        int? memoized_binomial_coefficient = binomial_coefficients[times, got];
        if (memoized_binomial_coefficient != null)
            return memoized_binomial_coefficient.Value;

        int next_times = times + 1;
        int next_got = got + 1;
        binomial_coefficients[times, got] = binomial_coefficient(next_times, got) + binomial_coefficient(next_times, next_got);
        return binomial_coefficients[times, got]!.Value;
    }
}