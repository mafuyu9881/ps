internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [1, 500]
        int width = tokens[1]; // [1, 500]
        int k = tokens[2]; // [1, 1'000'000'000]
        
        Func<int, int, int> ConvertIndex2DTo1D = (row, col) =>
        {
            return row * width + col;
        };

        int[] map = new int[height * width];
        LinkedList<int> candidates = new();
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                int index = ConvertIndex2DTo1D(row, col);
                map[index] = tokens[col];
                candidates.AddLast(index);
            }
        }

        LinkedList<LinkedList<int>> ccs = new();
        LinkedList<int> cc = null!;
        {
            const int Offsets = 4;
            int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
            int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

            bool[] visited = new bool[height * width];

            Queue<int> frontier = new();

            while (candidates.Count > 0)
            {
                if (frontier.Count < 1)
                {
                    int candidate = candidates.First!.Value;
                    candidates.RemoveFirst();

                    if (visited[candidate])
                        continue;

                    cc = new();
                    ccs.AddLast(cc);

                    visited[candidate] = true;
                    frontier.Enqueue(candidate);
                }

                int index = frontier.Dequeue();
                int row = index / width;
                int col = index % width;
                
                for (int i = 0; i < Offsets; ++i)
                {
                    int adjRow = row + RowOffsets[i];
                    if (adjRow < 0 || adjRow > height - 1)
                        continue;

                    int adjCol = col + ColOffsets[i];
                    if (adjCol < 0 || adjCol > width - 1)
                        continue;

                    int adjIndex = ConvertIndex2DTo1D(adjRow, adjCol);
                    if (visited[adjIndex])
                        continue;

                    if (Math.Abs(map[index] - map[adjIndex]) > k)
                        continue;

                    cc.AddLast(adjIndex);
                    visited[adjIndex] = true;
                    frontier.Enqueue(adjIndex);
                }
            }
        }
        Console.Write(ccs.Count);
    }
}