using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100'000]

        (int x, int y)[] coords = new (int, int)[n];
        float[] slopes = new float[n - 1];
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            coords[i] = (tokens[0], tokens[1]); // tokens' element = [-10^9, 10^9]

            if (i > 0)
            {
                var prevCoord = coords[i - 1];
                var currCoord = coords[i];

                slopes[i - 1] = (currCoord.y - prevCoord.y) / (float)(currCoord.x - prevCoord.x);
            }
        }

        int q = int.Parse(Console.ReadLine()!); // [1, 100'000]

        StringBuilder sb = new();
        for (int i = 0; i < q; ++i)
        {
            double k = double.Parse(Console.ReadLine()!); // (-10^9, 10^9)

            int lo = 0 - 1;
            int hi = coords.Length - 1; // the last candidate is '(coords' last index) - 1'
            while (lo < hi - 1)
            {
                int m = (lo + hi) / 2;

                if (k < coords[m].x)
                {
                    hi = m;
                }
                else if (k > coords[m + 1].x)
                {
                    lo = m;
                }
                else
                {
                    break;
                }
            }

            float slope = slopes[(lo + hi) / 2];
            if (slope > 0)
            {
                sb.AppendLine("1");
            }
            else if (slope < 0)
            {
                sb.AppendLine("-1");
            }
            else
            {
                sb.AppendLine("0");
            }
        }
        Console.Write(sb);
    }
}