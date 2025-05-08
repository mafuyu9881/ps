internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100]
        int r = tokens[1]; // [1, 100]

        (int x, int y)[] grains = new (int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 100
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0]; // [-100, 100]
            int y = tokens[1]; // [-100, 100]
            grains[i] = (x, y);
        }

        int maxCaptured = 0;
        (int x, int y) maxCapturedCoord = (0, 0);
        for (int x = -100; x <= 100; ++x) // tc = 200 + 1
        {
            for (int y = -100; y <= 100; ++y) // tc = 200 + 1
            {
                int captured = 0;
                for (int i = 0; i < n; ++i) // max tc = 100
                {
                    var grain = grains[i];
                    if ((grain.x - x) * (grain.x - x) + (grain.y - y) * (grain.y - y) <= r * r)
                    {
                        ++captured;
                    }
                }

                if (captured > maxCaptured)
                {
                    maxCaptured = captured;
                    maxCapturedCoord = (x, y);
                }
            }
        }
        Console.Write($"{maxCapturedCoord.x} {maxCapturedCoord.y}");
    }
}