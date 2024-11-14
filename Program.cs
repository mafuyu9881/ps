internal class Program
{
    private static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        long n = tokens[0];
        long k = tokens[1];

        long[] scores = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        long low = 0 - 1;
        long high = scores.Max() + 1;
        while (low < high - 1)
        {
            long mid = (low + high) / 2;

            long remainK = k;
            for (int i = 0; i < n; ++i)
            {
                remainK -= Math.Max(0, scores[i] - mid);
            }

            if (remainK < 0)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.Write(high);
    }
}