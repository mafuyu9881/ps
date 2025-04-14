using System.Text;

internal class Program
{
    private class DisjointSet
    {
        private int[] _parents = null!;

        public DisjointSet(int n)
        {
            _parents = new int[n];
            for (int i = 0; i < _parents.Length; ++i)
            {
                _parents[i] = i;
            }
        }
        
        public int Find(int x)
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

            if (aSetRepresentative < bSetRepresentative)
            {
                _parents[aSetRepresentative] = bSetRepresentative;
            }
            else if (aSetRepresentative > bSetRepresentative)
            {
                _parents[bSetRepresentative] = aSetRepresentative;
            }
        }
    }

    private static void Main(string[] args)
    {
        const int Blank = 0;

        int[] tokens = null!;

        // length = 2
        // element = [1, 10^5]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int q = tokens[1];

        int[] canvas = new int[n + 1];

        SortedSet<int> set = new();
        for (int i = 1; i < canvas.Length; ++i) // max tc = 10^5
        {
            set.Add(i);
        }

        DisjointSet ds = new(n + 1);
        
        for (int i = 0; i < q; ++i) // max tc = 10^5
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [1, n] = [1, 10^5]
            int b = tokens[1]; // [1, n] = [1, 10^5]
            int x = tokens[2]; // [1, 10^9]

            for (int j = a; j <= b; ++j) // average tc = α(10^5)
            {
                if (canvas[j] != Blank)
                {
                    j = ds.Find(j);
                }
                else
                {
                    canvas[j] = x;
                }
                ds.Union(j, b);
            }
        }

        StringBuilder sb = new();
        for (int i = 1; i < canvas.Length; ++i)
        {
            sb.Append($"{canvas[i]} ");
        }
        Console.Write(sb);
    }
}