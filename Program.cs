using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int extendedN = n + 1;

        int m = int.Parse(Console.ReadLine()!);

        int[] tokens;
        LinkedList<(int v, int cost)>[] adjList = new LinkedList<(int, int)>[extendedN];
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int v0 = tokens[0];
            int v1 = tokens[1];
            int cost = tokens[2];

            var v0Adjs = adjList[v0];
            if (v0Adjs == null)
            {
                v0Adjs = new();
                adjList[v0] = v0Adjs;
            }
            v0Adjs.AddLast((v1, cost));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int e = tokens[1];

        const int Infinity = -1;

        (int cost, LinkedList<int>? vList)[] minCosts = new (int, LinkedList<int>?)[extendedN];
        for (int i = 0; i < minCosts.Length; ++i)
        {
            minCosts[i] = ((i != s) ? Infinity : 0, null);
        }

        PriorityQueue<(int v, int cost, LinkedList<int> vList), int> pq = new();
        int selfCost = 0;
        LinkedList<int> sVList = new();
        sVList.AddLast(s);
        pq.Enqueue((s, selfCost, sVList), selfCost);
        while (pq.Count > 0)
        {
            var element = pq.Dequeue();
            int v = element.v;
            if (v == e)
                break;
                
            int cost = element.cost;
            var oldVList = element.vList;

            var adjs = adjList[v];
            if (adjs != null)
            {
                for (var node = adjs.First; node != null; node = node.Next)
                {
                    int adjV = node.Value.v;
                    int adjCost = node.Value.cost;

                    int oldCost = minCosts[adjV].cost;
                    int newCost = cost + adjCost;
                    if (oldCost == Infinity || oldCost > newCost)
                    {
                        LinkedList<int> newVList = new(oldVList);
                        newVList.AddLast(adjV);
                        minCosts[adjV] = (newCost, newVList);
                        pq.Enqueue((adjV, newCost, newVList), newCost);
                    }
                }
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{minCosts[e].cost}");
        var eVList = minCosts[e].vList;
        if (eVList != null) // never happens, just to prevent a compile error
        {
            output.AppendLine($"{eVList.Count}");
            for (var node = eVList.First; node != null; node = node.Next)
            {
                output.Append($"{node.Value} ");
            }
        }
        Console.Write(output);
    }
}