internal class Program
{
    private static void Main(string[] args)
    {
        const int Offsets = 2;
        int[] YOffsets = new int[Offsets] { -1, 1 };
        int[] XOffsets = new int[Offsets] { 1, 1 };

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [1, 1'000]
        int width = height * 2;
        int teacherCount = tokens[1]; // [0, 100'000]

        bool[] map = new bool[(height + 1) * (width + 1)];
        for (int i = 0; i < teacherCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0];
            int y = tokens[1];
            map[y * (width + 1) + x] = true;
        }

        const int InvalidHeight = -1;

        int[] highestHeights = new int[map.Length];
        for (int v = 0; v < highestHeights.GetLength(0); ++v)
        {
            highestHeights[v] = InvalidHeight;
        }

        Queue<(int v, int highestHeight)> frontier = new();

        int s = 0;
        highestHeights[s] = 0;
        frontier.Enqueue((s, 0));

        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();
            int v = element.v;
            int x = v % (width + 1);
            int y = v / (width + 1);
            int highestHeight = element.highestHeight;

            for (int i = 0; i < Offsets; ++i)
            {
                int adjY = y + YOffsets[i];
                if (adjY < 0 || adjY > height)
                    continue;

                int adjX = x + XOffsets[i];
                if (adjX < 0 || adjX > width)
                    continue;

                int adjV = adjY * (width + 1) + adjX;
                if (map[adjV])
                    continue;

                int oldHeight = highestHeights[adjV];
                int newHeight = Math.Max(adjY, highestHeight);
                if (oldHeight >= newHeight)
                    continue;

                highestHeights[adjV] = newHeight;
                frontier.Enqueue((adjV, newHeight));
            }
        }

        Console.Write(highestHeights[0 * (width + 1) + width]);
    }
}