using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [?, ?]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = ?
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 20'000]
            int m = tokens[1]; // [1, 20'000]

            // length = [1, 20'000]
            // element = [1, ?]
            int[] aSizes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] bSizes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            // max tc = 20'000 * log2(20'000) = 20'000 * 14.xxx
            Array.Sort(aSizes);
            Array.Sort(bSizes);

            int pairs = 0;
            for (int j = 0; j < aSizes.Length; ++j) // max tc = 20'000
            {
                int aSize = aSizes[j];
                
                int lo = -1;
                int hi = (bSizes.Length - 1) + 1;
                while (lo < hi - 1) // max tc = log2(20'000) = 13.xxx
                {
                    int mid = (hi + lo) / 2;
                    
                    int bSize = bSizes[mid];

                    if (aSize > bSize)
                    {
                        lo = mid;
                    }
                    else
                    {
                        hi = mid;
                    }
                }

                pairs += lo + 1;
            }
            sb.AppendLine($"{pairs}");
        }
        Console.Write(sb);
    }
}