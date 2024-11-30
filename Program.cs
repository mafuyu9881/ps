using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int exN = n + 1;

        int m = int.Parse(Console.ReadLine()!);

        LinkedList<(int v, int cost)>[] adjList = new LinkedList<(int, int)>[exN];
        for (int i = 0; i < m; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            int c = tokens[2];
            
            var adjs = adjList[a];
            if (adjs == null)
            {
                adjs = new();
                adjList[a] = adjs;
            }
            adjs.AddLast((b, c));
        }

        const int Infinity = -1;

        StringBuilder output = new();
        for (int s = 1; s < exN; ++s) // max tc = 100 (2 ≤ n ≤ 100)
        {
            int[] minCosts = new int[exN];
            for (int i = 0; i < minCosts.Length; ++i) // max tc = 101
            {
                minCosts[i] = (s != i) ? Infinity : 0;
            }
            
            PriorityQueue<(int v, int cost), int> pq = new();
            int selfCost = 0;
            pq.Enqueue((s, selfCost), selfCost);
            while (pq.Count > 0) // max tc = 100 * log2(100)
            {
                var element = pq.Dequeue();
                int v = element.v;
                int cost = element.cost;

                var adjs = adjList[v];
                if (adjs == null)
                    continue;

                for (var node = adjs.First; node != null; node = node.Next)
                {
                    var adjElement = node.Value;
                    int adjV = adjElement.v;
                    int adjCost = adjElement.cost;
                    
                    int oldCost = minCosts[adjV];
                    int newCost = cost + adjCost;
                    if (oldCost == Infinity || newCost < oldCost)
                    {
                        minCosts[adjV] = newCost;
                        pq.Enqueue((adjV, newCost), newCost);
                    }
                }
            }
            for (int i = 1; i < minCosts.Length; ++i)
            {
                int minCost = minCosts[i];
                output.Append($"{((minCost != Infinity) ? minCost : 0)} ");
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}