using System.Text;

internal class Program
{
    private static int _nodes;
    private static LinkedList<(int v, int weight)>[] _adjList = null!;

    private static void Main(string[] args)
    {
        int queries = int.Parse(Console.ReadLine()!); // [1, 200'000]

        _nodes = queries + 1;

        // max sc = nB * 200'000 = 0.2nMB (n = linked list size)
        _adjList = new LinkedList<(int, int)>[_nodes];

        StringBuilder output = new();
        for (int i = 0; i < queries; ++i) // max tc = 200'000
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int qi = tokens[0] - 1; // [0, i]
            int wi = tokens[1]; // [0, 1'000'000'000]

            if (_adjList[qi] == null) _adjList[qi] = new();
            if (_adjList[i + 1] == null) _adjList[i + 1] = new();

            _adjList[qi].AddLast((i + 1, wi));
            _adjList[i + 1].AddLast((qi, wi));

            var farthest0 = GetFarthest(qi);
            var farthest1 = GetFarthest(farthest0.v);
            output.AppendLine($"{farthest1.distance}");
        }
        Console.WriteLine(output);
    }

    private static (int v, long distance) GetFarthest(int startV)
    {
        const int InvalidV = -1;
        int farthestV = InvalidV;

        bool[] visited = new bool[_nodes];
        long[] distances = new long[_nodes];
        Stack<int> visitingStack = new();

        visited[startV] = true;
        distances[startV] = 0;
        visitingStack.Push(startV);

        while (visitingStack.Count > 0)
        {
            int v = visitingStack.Pop();

            var adjs = _adjList[v];
            for (var node = adjs.First; node != null; node = node.Next)
            {
                var adj = node.Value;
                int adjV = adj.v;
                int adjWeight = adj.weight;

                if (visited[adjV])
                    continue;

                long adjVDistance = distances[v] + adjWeight;
                if (farthestV == InvalidV || distances[farthestV] < adjVDistance)
                {
                    farthestV = adjV;
                }

                visited[adjV] = true;
                distances[adjV] = adjVDistance;
                visitingStack.Push(adjV);
            }
        }

        return (farthestV, distances[farthestV]);
    }
}