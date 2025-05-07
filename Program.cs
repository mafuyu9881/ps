internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 5'000]
        int c = tokens[1]; // [1, 100'000'000]

        // length = [1, 5'000]
        // element = [1, 100'000'000]
        int[] weights = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(weights);

        int satisfied = 0;
        {
            for (int i = 0; i < n; ++i) // max tc = 5'000
            {
                if (weights[i] == c)
                {
                    satisfied = 1;
                    goto End;
                }
            }

            int s = 0;
            int e = n - 1;
            while (s < e) // max tc = 5'000
            {
                int sum = weights[s] + weights[e];
                if (sum > c)
                {
                    --e;
                }
                else if (sum < c)
                {
                    ++s;
                }
                else
                {
                    satisfied = 1;
                    goto End;
                }
            }
            
            Func<int, int, int, bool> BinarySearch = (pair, lo, hi) =>
            {
                while (lo < hi - 1) // max tc = log2(5'000) = 12.xxxx
                {
                    int mid = (lo + hi) / 2;
                        
                    int tuple = pair + weights[mid];

                    if (tuple < c)
                    {
                        lo = mid;
                    }
                    else if (tuple > c)
                    {
                        hi = mid;
                    }
                    else
                    {
                        satisfied = 1;
                        return true;
                    }
                }

                return false;
            };

            for (int i = 0; i < n; ++i) // max tc = 5'000
            {
                for (int j = i + 1; j < n; ++j) // max tc = 5'000
                {
                    int pair = weights[i] + weights[j];
                    if (pair > c)
                        break;

                    if (BinarySearch(pair, (i + 1) - 1, (j - 1) + 1))
                        goto End;

                    if (BinarySearch(pair, (j + 1) + 1, (n - 1) + 1))
                        goto End;
                }
            }
        }
End:
        Console.Write(satisfied);
    }
}