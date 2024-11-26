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

        int maxDiameter = 0;
        for (int i = 1; i < extendedN; ++i)
        {
            GC.Collect();
            
            bool[] visited = new bool[extendedN];
            Stack<(int v, int weightSum)> stack = new();
            stack.Push(new(i, 0));
            visited[i] = true;
            while (stack.Count > 0)
            {
                var stackData = stack.Pop();
                int v = stackData.v;
                int oldWeightSum = stackData.weightSum;

                var adjs = adjList[v];
                if (adjs == null)
                    continue;

                for (var node = adjs.First; node != null; node = node.Next)
                {
                    int adjV = node.Value.v;
                    if (visited[adjV])
                        continue;

                    int newWeightSum = oldWeightSum + node.Value.weight;
                    maxDiameter = Math.Max(maxDiameter, newWeightSum);
                    stack.Push(new(adjV, newWeightSum));
                    visited[adjV] = true;
                }
            }
        }
        Console.Write(maxDiameter);
    }
}