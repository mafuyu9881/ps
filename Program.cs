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
            // length = [1, 30'000 - 1]
            // element = [0, 1'000'000]
            int[] ranges = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            (int coord, int range)[] pairs = new (int, int)[n];
            for (int i = 0; i < n - 1; ++i)
            {
                pairs[i] = (coords[i], ranges[i]);
            }
            Array.Sort(pairs, (x, y) => x.coord.CompareTo(y.coord));

            int arrival = coords[n - 1];

            int e = 0;

            for (int i = 0; i < pairs.Length; ++i)
            {
                int coord = pairs[i].coord;
                int range = pairs[i].range;

                if (e < coord)
                    break;

                e = Math.Max(e, coord + range);
            }

            if (e < arrival)
            {
                output = "엄마 나 전역 늦어질 것 같아";
            }
        }
        Console.Write(output);
    }
}