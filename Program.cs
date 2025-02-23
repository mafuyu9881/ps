internal class Program
{
    private static void Main(string[] args)
    {
        // element = [1, 100]
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = integerTokens[0];
        int height = integerTokens[1];

        LinkedList<int> waitings = new();
        char[] map = new char[width * height];
        for (int row = 0; row < height; ++row) // max tc = 100
        {
            string token = Console.ReadLine()!;
            for (int col = 0; col < width; ++col) // max tc = 100
            {
                int index = row * width + col;

                map[index] = token[col];

                waitings.AddLast(index);
            }
        }

        const int AdjOffsets = 4;
        int[] AdjRowOffsets = new int[AdjOffsets] { -1, 1, 0, 0 };
        int[] AdjColOffsets = new int[AdjOffsets] { 0, 0, -1, 1 };

        bool[] visited = new bool[map.Length];
        Queue<int> frontier = new();

        LinkedList<int> cc = null!;
        LinkedList<LinkedList<int>> wccs = new();
        LinkedList<LinkedList<int>> bccs = new();
        while (waitings.Count > 0) // max tc = 10'000
        {
            if (frontier.Count < 1)
            {
                var lln = waitings.First!;
                int llnValue = lln.Value;
                waitings.Remove(lln);

                if (visited[llnValue])
                    continue;
                
                visited[llnValue] = true;

                frontier.Enqueue(llnValue);
                
                cc = new();
                if (map[llnValue] == 'W')
                    wccs.AddLast(cc);
                else
                    bccs.AddLast(cc);
            }

            int index = frontier.Dequeue();
            int row = index / width;
            int col = index % width;

            cc.AddLast(index);

            for (int i = 0; i < AdjOffsets; ++i)
            {
                int adjRow = row + AdjRowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + AdjColOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                if (visited[adjIndex])
                    continue;

                if (map[index] != map[adjIndex])
                    continue;

                visited[adjIndex] = true;
                
                frontier.Enqueue(adjIndex);
            }
        }

        int wforce = 0;
        for (var lln = wccs.First; lln != null; lln = lln.Next)
        {
            wforce += lln.Value.Count * lln.Value.Count;
        }
        int bforce = 0;
        for (var lln = bccs.First; lln != null; lln = lln.Next)
        {
            bforce += lln.Value.Count * lln.Value.Count;
        }
        Console.Write($"{wforce} {bforce}");
    }
}