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

            int aSetRank = _ranks[a];
            int bSetRank = _ranks[b];
            if (aSetRank > bSetRank)
            {
                _parents[b] = a;
            }
            else if (aSetRank < bSetRank)
            {
                _parents[a] = b;
            }
            else
            {
                _parents[b] = a;
                ++_ranks[a];
            }
        }

        public bool United(int a, int b)
        {
            return Find(a) == Find(b);
        }
    }

    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int vertices = tokens[0]; // [2, 100'000]
        int edges = tokens[1]; // [1, 100'000]

        int operations = 0;
        {
            DisjointSet ds = new(vertices + 1);
            int root = 0;
            for (int i = 0; i < edges; ++i)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int u = tokens[0];
                int v = tokens[1];
                if (ds.United(u, v) == false)
                {
                    ds.Union(u, v);
                    root = u;
                    ++operations;
                }
            }

            for (int i = 1; i <= vertices; ++i)
            {
                if (ds.United(root, i) == false)
                {
                    ds.Union(root, i);
                    ++operations;
                }
            }
        }
        Console.Write(operations);
    }
}