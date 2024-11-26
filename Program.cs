internal class Program
{
    private struct ConnectionData // sc = 8B
    {
        private int _dst;
        public int Dst => _dst;
        private int _cost;
        public int Cost => _cost;

        public ConnectionData(int dst, int cost)
        {
            _dst = dst;
            _cost = cost;
        }
    }

    private struct AccData // sc = 8B
    {
        private int _v;
        public int V => _v;
        private int _oldCost;
        public int OldCost => _oldCost;

        public AccData(int v, int oldCost)
        {
            _v = v;
            _oldCost = oldCost;
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int extendedN = n + 1;

        // sc = (2n - 2) * 8B
        // max sc = 19998 * 8B = 159984B = approx 160KB
        List<ConnectionData>[] adjList = new List<ConnectionData>[extendedN];
        for (int i = 0; i < (n - 1); ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int parent = tokens[0];
            int child = tokens[1];
            int cost = tokens[2];

            var parentAdjs = adjList[parent];
            if (parentAdjs == null)
            {
                parentAdjs = new();
                adjList[parent] = parentAdjs;
            }
            parentAdjs.Add(new ConnectionData(child, cost));

            var childAdjs = adjList[child];
            if (childAdjs == null)
            {
                childAdjs = new();
                adjList[child] = childAdjs;
            }
            childAdjs.Add(new ConnectionData(parent, cost));
        }

        int maxDiameter = 0;
        for (int i = 1; i < extendedN; ++i) // tc = n, max tc = 10000
        {
            bool[] visited = new bool[extendedN]; // sc = 1B * n, max sc = 10000B = 10KB
            Stack<AccData> stack = new(); // sc = 8B * n, max sc = 80000B = 80KB
            stack.Push(new(i, 0));
            visited[i] = true;
            while (stack.Count > 0) // tc = n, max tc = 10000
            {
                AccData accData = stack.Pop();
                int v = accData.V;
                int oldCost = accData.OldCost;

                var adjs = adjList[v];
                if (adjs == null)
                    continue;

                for (int j = 0; j < adjs.Count; ++j) // max tc = 3
                {
                    int adjV = adjs[j].Dst;
                    if (visited[adjV])
                        continue;

                    int newCost = oldCost + adjs[j].Cost;
                    maxDiameter = Math.Max(maxDiameter, newCost);
                    stack.Push(new(adjV, newCost));
                    visited[adjV] = true;
                }
            }
        }
        Console.Write(maxDiameter);
    }
}