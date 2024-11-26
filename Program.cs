internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int extendedN = n + 1;

        LinkedList<(int v, int weight)>[] adjList = new LinkedList<(int, int)>[extendedN];
        for (int i = 0; i < (n - 1); ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int parent = tokens[0];
            int child = tokens[1];
            int weight = tokens[2];

            var parentAdjs = adjList[parent];
            if (parentAdjs == null)
            {
                parentAdjs = new();
                adjList[parent] = parentAdjs;
            }
            parentAdjs.AddLast((child, weight));

            var childAdjs = adjList[child];
            if (childAdjs == null)
            {
                childAdjs = new();
                adjList[child] = childAdjs;
            }
            childAdjs.AddLast((parent, weight));
        }

        DFS(out int maxAccWeight, out int diameterV0, extendedN, 1, adjList);
        DFS(out int maxDiameter, out int diameterV1, extendedN, diameterV0, adjList);
        Console.Write(maxDiameter);
    }

    private static void DFS(out int maxAccWeight, out int farthestV, int n, int s, LinkedList<(int v, int weight)>[] adjList)
    {
        maxAccWeight = 0;
        farthestV = s;

        bool[] visited = new bool[n];
        Stack<(int v, int accWeight)> stack = new();
        stack.Push((s, 0));
        visited[s] = true;
        while (stack.Count > 0)
        {
            var element = stack.Pop();
            int v = element.v;
            int oldAccWeight = element.accWeight;

            var adjs = adjList[v];
            if (adjs == null)
                continue;

            for (var node = adjs.First; node != null; node = node.Next)
            {
                int adjV = node.Value.v;
                if (visited[adjV])
                    continue;

                int newAccWeight = oldAccWeight + node.Value.weight;
                if (newAccWeight > maxAccWeight)
                {
                    maxAccWeight = newAccWeight;
                    farthestV = adjV;
                }
                stack.Push((adjV, newAccWeight));
                visited[adjV] = true;
            }
        }
    }
}