using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int vertices = tokens[0]; // [1, 300]
        int edges = tokens[1]; // [1, 25'000]
        int t = tokens[2]; // [1, 40'000]

        LinkedList<(int dstV, int cost)>[] adjList = new LinkedList<(int, int)>[vertices + 1];
        for (int i = 0; i < adjList.Length; ++i)
        {
            adjList[i] = new();
        }

        for (int i = 0; i < edges; ++i) // max tc = 25'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            // [1, 300]
            int u = tokens[0];
            int v = tokens[1];

            int cost = tokens[2]; // [1, 1'000'000]

            adjList[u].AddLast((v, cost));
        }

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 40'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            // [1, 300]
            int s = tokens[0];
            int e = tokens[1];

            PriorityQueue<(int dstV, int cost), int> pq = new();

            bool[] visited = new bool[adjList.Length + 1]; // max sc = 301 * 4B = about 1.2KB

            visited[s] = true;
            for (var lln = adjList[s].First; lln != null; lln = lln.Next) // max tc = 25'000
            {
                int dstV = lln.Value.dstV;
                int cost = lln.Value.cost;
                pq.Enqueue((dstV, cost), cost);
            }

            const int InvalidCost = -1;
            int maxCost = InvalidCost;
            while (pq.Count > 0) // max tc = 25'000
            {
                var element = pq.Dequeue();

                int dstV = element.dstV;
                if (visited[dstV])
                    continue;

                int cost = element.cost;
                if (maxCost == InvalidCost || cost > maxCost)
                    maxCost = cost;

                visited[dstV] = true;
                if (dstV == e)
                    break;

                for (var lln = adjList[dstV].First; lln != null; lln = lln.Next)
                {
                    int adjDstV = lln.Value.dstV;
                    int adjCost = lln.Value.cost;
                    pq.Enqueue((adjDstV, adjCost), adjCost);
                }
            }

            if (visited[e])
            {
                sb.AppendLine($"{maxCost}");
            }
            else
            {
                sb.AppendLine("-1");
            }
        }
        Console.Write(sb);
    }
}