public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        long prev = 1;
        long curr = 1;
        for (int i = 3; i <= n; ++i)
        {
            long next = (prev + curr) % 1000000007;
            prev = curr;
            curr = next;
        }

        Console.Write($"{curr} {n - 2}");
    }
}