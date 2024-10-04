internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        int[] coins = new int[n];
        for (int i = 0; i < n; ++i)
        {
            coins[i] = int.Parse(Console.ReadLine()!);
        }

        int entireCount = 0;
        for (int i = n - 1; (k > 0) && (i > -1); --i)
        {
            int coin = coins[i];

            int count = k / coin;

            k -= coin * count;

            entireCount += count;
        }
        Console.Write(entireCount);
    }
}