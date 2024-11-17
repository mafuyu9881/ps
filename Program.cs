using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];

        LinkedList<int>[] adjList = new LinkedList<int>[n];
        for (int i = 0; i < n; ++i) // max tc = n = 250 (1 <= n <= 250)
        {
            adjList[i] = new();
        }
        for (int i = 0; i < m; ++i) // max tc = 250 * (250 - 1) / 2 = 31,125 (1 <= m <= n*(n-1)/2)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int c0 = tokens[0] - 1;
            int c1 = tokens[1] - 1;

            adjList[c0].AddLast(c1);
            adjList[c1].AddLast(c0);
        }

        bool[] visitedTable = new bool[n];
        Queue<int> visitingQueue = new();
        int v0 = 0;
        visitingQueue.Enqueue(v0);
        visitedTable[v0] = true;
        while (visitingQueue.Count > 0)
        {
            int v = visitingQueue.Dequeue();

            var adjs = adjList[v];
            for (var node = adjs.First; node != null; node = node.Next) // max tc = n - 1 (exclude self)
            {
                int adjV = node.Value;

                if (visitedTable[adjV])
                    continue;

                visitingQueue.Enqueue(adjV);
                visitedTable[adjV] = true;
            }
        }
        
        StringBuilder output = new();
        for (int v = 0; v < n; ++v) // max tc = n = 250 (1 <= n <= 250)
        {
            if (visitedTable[v])
                continue;
            
            output.AppendLine($"{v + 1}");
        }
        Console.Write((output.Length < 1) ? "0" : output);
    }
}