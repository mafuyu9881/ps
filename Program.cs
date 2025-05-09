internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 30'000]

        // length = [1, 30'000]
        // element = [0, 1'000'000]
        int[] coords = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        string output = "권병장님, 중대장님이 찾으십니다";
        if (n > 1)
        {
            int endCoord = coords[n - 1];

            // length = [1, 30'000 - 1]
            // element = [0, 1'000'000]
            int[] ranges = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            //(int coord, int range)[] pairs = new (int, int)[n];
            //for (int i = 0; i < n - 1; ++i)
            //{
            //    pairs[i] = (coords[i], ranges[i]);
            //}
            ////pairs[n - 1] = (coords[n - 1], 0);
            //Array.Sort(pairs, (x, y) => x.coord.CompareTo(y.coord));

            // pre-processed
            int[] ppPrefixSum = new int[endCoord + 2];
            for (int i = 0; i < n - 1; ++i)
            {
                int coord = coords[i];
                int range = ranges[i];

                int s = Math.Max(coord - range, 0);
                int e = Math.Min(coord + range, endCoord);

                ppPrefixSum[s] += 1;
                ppPrefixSum[e + 1] -= 1;
            }

            for (int i = 1; i < ppPrefixSum.Length; ++i)
            {
                ppPrefixSum[i] += ppPrefixSum[i - 1];
            }

            int x = 0;
            while (x < ppPrefixSum.Length)
            {
                if (ppPrefixSum[x] > 0)
                {
                    ++x;
                }
                else
                {
                    break;
                }
            }

            if (x < endCoord)
            {
                output = "엄마 나 전역 늦어질 것 같아";
            }
        }
        Console.Write(output);
    }
}