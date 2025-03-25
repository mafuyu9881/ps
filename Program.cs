internal class Program
{
    const int InvalidElement = -1;

    private static void Main(string[] args)
    {
        // length = 2
        // element = [1, 1'000'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        int[,] dp = new int[b + 1, 2];
        for (int i = 0; i <= b; ++i)
        {
            dp[i, 0] = InvalidElement;
            dp[i, 1] = InvalidElement;
        }

        dp[a, 0] = 0;
        dp[a, 1] = 0;
        for (int i = a; i <= b; ++i)
        {
            int j = i + 1;
            if (j <= b)
            {
                Update(ref dp[j, 0], dp[i, 0] + 1);
                Update(ref dp[j, 1], dp[i, 1] + 1);
            }

            int k = i * 2;
            if (k <= b)
            {
                Update(ref dp[k, 0], dp[i, 0] + 1);
                Update(ref dp[k, 1], dp[i, 1] + 1);
            }

            int l = i * 10;
            if (l <= b)
            {
                Update(ref dp[l, 1], dp[i, 0] + 1);
            }
        }

        Console.Write(Math.Min(dp[b, 0], dp[b, 1]));
    }

    private static void Update(ref int element, int value)
    {
        if (element == InvalidElement)
        {
            element = value;
        }
        else
        {
            element = Math.Min(element, value);
        }
    }
}