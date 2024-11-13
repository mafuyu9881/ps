internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];
        int m = tokens[2];

        int[] lengths = new int[n];
        for (int i = 0; i < n; ++i)
        {
            lengths[i] = int.Parse(Console.ReadLine()!);
        }

        int low = 1 - 1;
        int high = 1000000000 + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int remainM = m;
            for (int i = 0; i < n; ++i)
            {
                int length = lengths[i];

                if (length <= k)
                    continue;

                if (length < 2 * k)
                {
                    length -= k;
                }
                else
                {
                    length -= 2 * k;
                }

                remainM = Math.Max(0, remainM - (length / mid));
            }

            if (remainM > 0)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write((low != 0) ? low : -1);
    }
}