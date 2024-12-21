using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 5 ≤ n ≤ 25

        const int Offsets = 4;
        int[] rowOffsets = new int[Offsets] { -1, +1, 0, 0 };
        int[] colOffsets = new int[Offsets] { 0, 0, -1, 1 };

        int[] map = new int[n * n];
        LinkedList<int> waitingVisits = new();
        Dictionary<int, LinkedList<int>?> dictionary = new();
        for (int row = 0; row < n; ++row)
        {
            string token = Console.ReadLine()!;
            for (int col = 0; col < n; ++col)
            {
                int index = row * n + col;
                map[index] = token[col] - '0'; // tokens[i] = 0 or 1
                waitingVisits.AddLast(index);
                dictionary.Add(index, null);
            }
        }

        LinkedList<int> emptyConnectedComponent = new();
        LinkedList<LinkedList<int>> connectedComponents = new();
        Queue<int> visitingQueue = new();
        while (true)
        {
            if (visitingQueue.Count < 1)
            {
                if (waitingVisits.Count < 1)
                    break;

                var node = waitingVisits.First!;
                visitingQueue.Enqueue(node.Value);
                waitingVisits.Remove(node);
            }

            int srcIndex = visitingQueue.Dequeue();

            LinkedList<int>? connectedComponent = dictionary[srcIndex];
            if (connectedComponent == null)
            {
                if (map[srcIndex] == 0)
                {
                    connectedComponent = emptyConnectedComponent;
                    continue;
                }
                else
                {
                    connectedComponent = new();
                    connectedComponent.AddLast(srcIndex);
                    connectedComponents.AddLast(connectedComponent);
                    dictionary[srcIndex] = connectedComponent;
                }
            }

            int srcRow = srcIndex / n;
            int srcCol = srcIndex % n;
            for (int i = 0; i < Offsets; ++i)
            {
                int adjRow = srcRow + rowOffsets[i];
                if (adjRow < 0 || adjRow > n - 1)
                    continue;

                int adjCol = srcCol + colOffsets[i];
                if (adjCol < 0 || adjCol > n - 1)
                    continue;

                int adjIndex = adjRow * n + adjCol;
                if (dictionary[adjIndex] != null) // already visited
                    continue;

                if (map[adjIndex] == 0)
                    continue;

                connectedComponent.AddLast(adjIndex);
                dictionary[adjIndex] = connectedComponent;
                visitingQueue.Enqueue(adjIndex);
            }
        }

        PriorityQueue<LinkedList<int>, int> connectedComponentPQ = new();
        for (var node = connectedComponents.First; node != null; node = node.Next)
        {
            var connectedComponent = node.Value;
            connectedComponentPQ.Enqueue(connectedComponent, connectedComponent.Count);
        }

        StringBuilder output = new();
        output.AppendLine($"{connectedComponentPQ.Count}");
        while (connectedComponentPQ.Count > 0)
        {
            output.AppendLine($"{connectedComponentPQ.Dequeue().Count}");
        }
        Console.Write(output);
    }
}