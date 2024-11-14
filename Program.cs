internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        int[] heights = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int low = 0 - 1;
        int high = heights.Max() + 1;
        while (low < high - 1)
        {
            int mid = (int)((low + (long)high) / 2);

            int exhaustedCount = 0;
            for (int i = 0; i < n; ++i)
            {
                int myHeight = heights[i];

                bool exhausted = false;

                if (i > 0 &&
                    Math.Abs(myHeight - heights[i - 1]) > mid)
                {
                    exhausted |= true;
                }

                if (i < (n - 1) &&
                    Math.Abs(myHeight - heights[i + 1]) > mid)
                {
                    exhausted |= true;
                }

                if (exhausted == false)
                    continue;

                ++exhaustedCount;
            }
            
            if (exhaustedCount > k)
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