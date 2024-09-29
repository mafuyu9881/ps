// 시간 제한: 0.15초
// 메모리 제한: 128MB
// 1 <= N <= 10^6

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] computing_counts = new int[n + 1];
        computing_counts[0] = 1;
        for (int i = 2; i <= n; ++i)
        {
            int new_computing_count = computing_counts[i - 1] + 1;

            if (i % 2 == 0)
                new_computing_count = Math.Min(new_computing_count, computing_counts[i / 2] + 1);

            if (i % 3 == 0)
                new_computing_count = Math.Min(new_computing_count, computing_counts[i / 3] + 1);
            
            computing_counts[i] = new_computing_count;
        }
        Console.Write(computing_counts[n]);
    }
}