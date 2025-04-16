internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 10'000'000]

        int i = 0;
        int j = 0;

        int cnt = 0;
        {
            int sum = 0;
            while (i <= n && j <= n)
            {
                if (sum > n)
                {
                    sum -= i;
                    ++i;
                }
                else
                {
                    ++j;
                    sum += j;
                }

                if (sum == n)
                {
                    ++cnt;
                }
            }
        }
        Console.Write(cnt);
    }
}