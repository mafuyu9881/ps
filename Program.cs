class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        // length = 2
        // element = [1, 50]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[] map = new int[height * width];
        for (int row = 0; row < height; ++row) // max tc = 50
        {
            // length = width
            // element = [0, 9]
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col) // max tc = 50
            {
                map[row * width + col] = tokens[col];
            }
        }

        int password = 0;
        {
            const int Offsets = 4;
            int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
            int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

            bool[] visited = new bool[map.Length];
            Queue<(int index, bool cycle, int pathLength)> frontier = new();

            int maxPathLength = 0;

            for (int s = 0; s < map.Length; ++s) // max tc = 2'500
            {
                if (map[s] == 0)
                    continue;

                for (int i = 0; i < visited.Length; ++i) // max tc = 2'500
                {
                    visited[i] = false;
                }
                frontier.Clear();

                visited[s] = true;
                frontier.Enqueue((s, false, 0));

                while (frontier.Count > 0)
                {
                    var element = frontier.Dequeue();
                    int index = element.index;
                    int row = index / width;
                    int col = index % width;
                    bool cycle = element.cycle;
                    int pathLength = element.pathLength;

                    for (int i = 0; i < Offsets; ++i) // tc = 4
                    {
                        int adjRow = row + RowOffsets[i];
                        if (adjRow < 0 || adjRow > height - 1)
                            continue;

                        int adjCol = col + ColOffsets[i];
                        if (adjCol < 0 || adjCol > width - 1)
                            continue;

                        int adjIndex = adjRow * width + adjCol;
                        if (visited[adjIndex] ||
                            (map[adjIndex] == 0) ||
                            (cycle && adjIndex == s))
                            continue;

                        int candidate = map[s] + map[adjIndex];
                        int newPassLength = pathLength + 1;
                        if (newPassLength > maxPathLength)
                        {
                            password = candidate;
                            maxPathLength = newPassLength;
                        }
                        else if (newPassLength == maxPathLength)
                        {
                            password = Math.Max(password, candidate);
                            maxPathLength = newPassLength;
                        }

                        visited[adjIndex] = true;
                        frontier.Enqueue((adjIndex, adjIndex == s, newPassLength));
                    }
                }
            }
        }
        Console.Write(password);
    }
}