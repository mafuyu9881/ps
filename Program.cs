using System.Text;

internal class Program
{
    private struct ConnectionData
    {
        private int _v;
        public int V => _v;
        private int _dist;
        public int Dist => _dist;

        public ConnectionData(int v, int dist)
        {
            _v = v;
            _dist = dist;
        }
    }

    private static void Main(string[] args)
    {
        int v = int.Parse(Console.ReadLine()!);
        int extendedV = v + 1;

        LinkedList<ConnectionData>[] adjList = new LinkedList<ConnectionData>[extendedV];
        for (int i = 0; i < v; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int v0 = tokens[0];

            for (int j = 1; j < tokens.Length; j += 2)
            {
                if (tokens[j] == -1)
                    break;

                int v1 = tokens[j];
                int dist = tokens[j + 1];

                var v0Adjs = adjList[v0];
                if (v0Adjs == null)
                {
                    v0Adjs = new();
                    adjList[v0] = v0Adjs;
                }
                v0Adjs.AddLast(new ConnectionData(v1, dist));

                var v1Adjs = adjList[v1];
                if (v1Adjs == null)
                {
                    v1Adjs = new();
                    adjList[v1] = v1Adjs;
                }
                v1Adjs.AddLast(new ConnectionData(v0, dist));
            }
        }

        DFS(out int maxAccDist, out int diameterV0, extendedV, 1, adjList);
        DFS(out int diameter, out int diameterV1, extendedV, diameterV0, adjList);
        Console.Write(diameter);
    }

    private static void DFS(out int maxAccDist, out int farthestV, int n, int s, LinkedList<ConnectionData>[] adjList)
    {
        maxAccDist = 0;
        farthestV = s;

        bool[] visited = new bool[n];
        Stack<(int v, int accDist)> stack = new();
        stack.Push((s, 0));
        visited[s] = true;
        while (stack.Count > 0)
        {
            var element = stack.Pop();
            int v = element.v;
            int oldAccDist = element.accDist;
            
            var adjs = adjList[v];
            if (adjs == null)
                continue;

            for (var node = adjs.First; node != null; node = node.Next)
            {
                int adjV = node.Value.V;
                if (visited[adjV])
                    continue;

                int newAccDist = oldAccDist + node.Value.Dist;
                if (newAccDist > maxAccDist)
                {
                    maxAccDist = newAccDist;
                    farthestV = adjV;
                }
                stack.Push((adjV, newAccDist));
                visited[adjV] = true;
            }
        }
    }
}