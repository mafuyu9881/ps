internal class Program
{
    private static void Main(string[] args)
    {
        // length = 3
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 80]
        int k = tokens[1]; // [1, n] = [1, 80]
        int x = tokens[2]; // [1, 200]

        (int a, int b)[] people = new (int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 80
        {
            // length = 2
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [0, 200]
            int b = tokens[1]; // [0, 200]
            people[i] = (a, b);
        }
        
        Array.Sort(people, (x, y) => Math.Abs(y.a - y.b).CompareTo(Math.Abs(x.a - x.b)));

        int dpHeight = people.Length + 1;
        int dpWidth = k + 1;

        (int sa, int sb)[,] dp = new (int, int)[dpHeight, dpWidth];
        for (int i = 1; i < dpHeight; ++i)
        {
            for (int j = 1; j < dpWidth; ++j)
            {
                // prevent to leave the element as (0, 0)
                dp[i, j].sa = dp[i - 1, j - 1].sa + people[i - 1].a;
                dp[i, j].sb = dp[i - 1, j - 1].sb + people[i - 1].b;

                if ((dp[i - 1, j].sa * dp[i - 1, j].sb) > (dp[i, j].sa * dp[i, j].sb))
                {
                    dp[i, j].sa = dp[i - 1, j].sa;
                    dp[i, j].sb = dp[i - 1, j].sb;
                }
            }
        }
        Console.Write(dp[n, k].sa * dp[n, k].sb);
    }
}