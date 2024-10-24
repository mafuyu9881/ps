internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        DisjointSet disjointSet = new(n);
        int output = 0;
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            int a = tokens[0];
            int b = tokens[1];

            if (disjointSet.Union(a, b))
                continue;

            output = i + 1;
            break;
        }
        Console.Write(output);
    }

    private class DisjointSet
    {
        private int[]? _ranks;
        private int[]? _parents;

        public DisjointSet(int n)
        {
            _ranks = new int[n];

            _parents = new int[n];
            for (int i = 0; i < _parents.Length; ++i)
            {
                _parents[i] = i;
            }
        }

        public int Find(int x)
        {
            if (x == _parents![x])
            {
                return x;
            }
            else
            {
                return _parents[x] = Find(_parents[x]);
            }
        }

        public bool Union(int a, int b)
        {
            int aSetRepresentative = Find(a);
            int bSetRepresentative = Find(b);

            if (aSetRepresentative == bSetRepresentative)
                return false;

            int aSetRank = _ranks![aSetRepresentative];
            int bSetRank = _ranks[bSetRepresentative];

            if (aSetRank > bSetRank)
            {
                _parents![bSetRepresentative] = aSetRepresentative;
            }
            else if (aSetRank < bSetRank)
            {
                _parents![aSetRepresentative] = bSetRepresentative;
            }
            else
            {
                _parents![bSetRepresentative] = aSetRepresentative;
                ++_ranks[aSetRepresentative];
            }

            return true;
        }
    }
}