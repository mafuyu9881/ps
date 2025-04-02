internal class Program
{
    private class DisjointSet
    {
        private int[] _parents = null!;
        private int[] _ranks = null!;

        public DisjointSet(int n)
        {
            _parents = new int[n];
            for (int i = 0; i < _parents.Length; ++i)
            {
                _parents[i] = i;
            }

            _ranks = new int[n];
        }
        
        private int Find(int x)
        {
            int parent = _parents[x];
            if (parent != x)
            {
                _parents[x] = Find(parent);
            }
            return _parents[x];
        }

        public void Union(int a, int b)
        {
            int aSetRepresentative = Find(a);
            int bSetRepresentative = Find(b);
            if (aSetRepresentative == bSetRepresentative)
                return;

            int aSetRank = _ranks[aSetRepresentative];
            int bSetRank = _ranks[bSetRepresentative];
            if (aSetRank > bSetRank)
            {
                _parents[bSetRepresentative] = aSetRepresentative;
            }
            else if (aSetRank < bSetRank)
            {
                _parents[aSetRepresentative] = bSetRepresentative;
            }
            else
            {
                _parents[bSetRepresentative] = aSetRepresentative;
                ++_ranks[aSetRepresentative];
            }

            Find(a);
            Find(b);
        }

        public bool United(int a, int b)
        {
            return Find(a) == Find(b);
        }

        public bool United()
        {
            if (_parents.Length < 1)
                return true;

            for (int i = 2; i < _parents.Length; ++i)
            {
                if (United(1, i) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }

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

        PriorityQueue<(int h1, int h2, int weightLimit), int> pq = new();
        for (int i = 0; i < m; ++i) // max tc = m = 300'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2

            int h1 = tokens[0]; // [1, n] = [1, 100'000]
            int h2 = tokens[1]; // [1, n] = [1, 100'000]
            int k = tokens[2]; // [1, 1'000'000]

            pq.Enqueue((h1, h2, k), -k);
        }

        DisjointSet ds = new(adjList.Length);
        while (ds.United() == false && pq.Count > 0)
        {
            var element = pq.Dequeue();
            int h1 = element.h1;
            int h2 = element.h2;
            if (ds.United(h1, h2))
                continue;
            
            int weightLimit = element.weightLimit;
            adjList[h1].AddLast((h2, weightLimit));
            adjList[h2].AddLast((h1, weightLimit));
        }

        const int Infinity = -1;

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

                int oldMaxCapacity = maxCapacity[adjV];
                if (oldMaxCapacity == Infinity)
                    continue;

                int newMaxCapacity = lln.Value.weightLimit;
                if (capacity != Infinity)
                    newMaxCapacity = Math.Min(newMaxCapacity, capacity);
                
                if (oldMaxCapacity >= newMaxCapacity)
                    continue;

                maxCapacity[adjV] = newMaxCapacity;
                frontier.Enqueue((adjV, newMaxCapacity));
            }
        }
        Console.Write(maxCapacity[e]);
    }
}