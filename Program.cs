internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 200'000]
        int k = tokens[1]; // [2, n) = [2, 200'000)

        Func<int, bool> Condition = (t) =>
        {
            int day = n;

            bool[] visited = new bool[n + 1];
            visited[n] = true;

            int travels = 0;
            while (true)
            {
                if (tokens[day - 1] == 1)
                {
                    day = Math.Max(1, day - t);
                    ++travels;
                }
                else
                {
                    ++day;
                }

                if (travels > k)
                    return false;

                if (visited[day])
                    return false;

                visited[day] = true;

                if (day == 1)
                    return true;
            }
        };

        // length = [2, 200'000]
        // element = [0, 1]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int lo = 0 - 1;
        int hi = n + 1;
        while (lo < hi - 1)
        {
            int mid = (lo + hi) / 2;

            if (Condition(mid))
            {
                hi = mid;
            }
            else
            {
                lo = mid;
            }
        }
        Console.Write(hi);
    }
}