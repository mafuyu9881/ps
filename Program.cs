internal class Program
{
    private class DisjointSet
    {
        private int[] _parent = null!;
        private int[] _rank = null!;

        public DisjointSet(int n)
        {
            _parent = new int[n];
            for (int i = 0; i < _parent.Length; ++i)
            {
                _parent[i] = i;
            }

            _rank = new int[n];
        }
        
        public int Find(int x)
        {
            int parent = _parent[x];

            if (parent != x)
            {
                return _parent[x] = Find(parent); // find with path compressing
            }
            else
            {
                return x; // it's a representative
            }
        }

        public void Union(int a, int b)
        {
            int aSetRepresentative = Find(a);
            int bSetRepresentative = Find(b);

            if (aSetRepresentative == bSetRepresentative)
                return;

            int aSetRank = _rank[aSetRepresentative];
            int bSetRank = _rank[bSetRepresentative];

            if (aSetRank > bSetRank)
            {
                _parent[bSetRepresentative] = aSetRepresentative;
            }
            else if (aSetRank < bSetRank)
            {
                _parent[aSetRepresentative] = bSetRepresentative;
            }
            else
            {
                _parent[bSetRepresentative] = aSetRepresentative;
                ++_rank[aSetRepresentative];
            }

            // path compressing
            Find(a);
            Find(b);
        }

        public bool United()
        {
            if (_parent.Length < 1)
                return true; // undefined behaviour

            for (int i = 1; i < _parent.Length; ++i) // max tc = 50
            {
                if (_parent[Find(i)] != _parent[Find(0)])
                {
                    return false;
                }
            }

            return true;
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50]

        PriorityQueue<(int s, int e, int cost), int> frontier = new();

        int donatable = 0;

        for (int s = 0; s < n; ++s)
        {
            string stringToken = Console.ReadLine()!;
            for (int e = 0; e < n; ++e)
            {
                char charToken = stringToken[e];

                if (charToken != '0')
                {
                    int cost;
                    if (charToken >= 'a' && charToken <= 'z')
                    {
                        cost = charToken - 'a' + 1;
                    }
                    else
                    {
                        cost = charToken - 'A' + 27;
                    }

                    frontier.Enqueue((s, e, cost), cost);

                    donatable += cost;
                }
            }
        }

        DisjointSet ds = new(n);

        while (frontier.Count > 0)
        {
            var secost = frontier.Dequeue();
            int s = secost.s;
            int e = secost.e;

            if (ds.Find(s) == ds.Find(e))
                continue;

            ds.Union(s, e);

            donatable -= secost.cost;
        }

        if (ds.United() == false)
            donatable = -1;
            
        Console.Write(donatable);
    }
}