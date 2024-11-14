internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int k = tokens[1];
        int[] levels = new int[n];
        for (int i = 0; i < n; ++i)
        {
            levels[i] = int.Parse(Console.ReadLine()!);
        }

        int low = 1 - 1;
        int high = 2000000000 + 1;
        while (low < high - 1)
        {
            int mid = (int)((low + (long)high) / 2);

            int remainK = k;
            for (int i = 0; i < n; ++i)
            {
                remainK = Math.Max(-1, remainK - Math.Max(0, mid - levels[i]));
            }

            if (remainK < 0)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write(low);
    }
}