internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
        int n = tokens[0]; // [2, 100'000]
        int m = tokens[1]; // [1, 300'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
        int s = tokens[0]; // [1, n] = [1, 100'000]
        int e = tokens[1]; // [1, n] = [1, 100'000]

        LinkedList<(int v, int weightLimit)>[] adjList = new LinkedList<(int, int)>[n + 1];
        for (int i = 0; i < adjList.Length; ++i) // max tc = n = 100'000
        {
            adjList[i] = new();
        }

        for (int i = 0; i < m; ++i) // max tc = m = 300'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
            int h1 = tokens[0]; // [1, n] = [1, 100'000]
            int h2 = tokens[1]; // [1, n] = [1, 100'000]
            int k = tokens[2]; // [1, 1'000'000]
            adjList[h1].AddLast((h2, k));
            adjList[h2].AddLast((h1, k));
        }

        const int Infinity = -2;

        int[] maxCapacity = new int[adjList.Length];

        Queue<(int v, int capacity)> frontier = new();

        maxCapacity[s] = Infinity;
        frontier.Enqueue((s, maxCapacity[s]));
        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();

            int v = element.v;
            int capacity = element.capacity;

            var adjs = adjList[v];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adjV = lln.Value.v;

                int oldAdjVCapacity = maxCapacity[adjV];
                if (oldAdjVCapacity == Infinity)
                    continue;

                int newAdjVCapacity = lln.Value.weightLimit;
                if (capacity != Infinity)
                    newAdjVCapacity = Math.Min(newAdjVCapacity, capacity);

                if (oldAdjVCapacity >= newAdjVCapacity)
                    continue;

                maxCapacity[adjV] = newAdjVCapacity;
                frontier.Enqueue((adjV, maxCapacity[adjV]));
            }
        }
        Console.Write(maxCapacity[e]);
    }
}