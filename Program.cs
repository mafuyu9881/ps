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

            if (x != parent)
            {
                // return Find(parent); // find without path compressing
                return _parent[x] = Find(parent); // find with path compressing
            }
            else
            {
                return x;
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
            if (_parent.Length < 0)
                return true; // undefined behaviour

            for (int i = 1; i < _parent.Length; ++i)
            {
                if (Find(i) != Find(0))
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

        int donated = 0;

        PriorityQueue<(int s, int e, int cost), int> cables = new();

        for (int s = 0; s < n; ++s) // max tc = 50
        {
            string stringToken = Console.ReadLine()!;
            for (int e = 0; e < n; ++e) // max tc = 50
            {
                char charToken = stringToken[e];

                int cost = 0;
                if (charToken >= 'a' && charToken <= 'z')
                {
                    cost = charToken - 'a' + 1;
                }
                else if (charToken >= 'A' && charToken <= 'Z')
                {
                    cost = charToken - 'A' + 27;
                }

                donated += cost;

                cables.Enqueue((s, e, cost), cost);
            }
        }

        DisjointSet ds = new(n);
        
        while (cables.Count > 0) // max tc = 2'500
        {
            var cable = cables.Dequeue();
            int s = cable.s;
            int e = cable.e;
            int cost = cable.cost;

            if ((ds.Find(s) == ds.Find(e)) || (cost < 1))
                continue;

            ds.Union(s, e);

            donated -= cost;
        }

        if (ds.United() == false)
            donated = -1;

        Console.Write(donated);
    }
}