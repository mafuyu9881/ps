using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];
        
        DisjointSet disjointSet = new(n);

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int command = tokens[0];
            int a = tokens[1];
            int b = tokens[2];

            if (command == 0)
            {
                disjointSet.Union(a, b);
            }
            else
            {
                output.AppendLine((disjointSet.Find(a) == disjointSet.Find(b)) ? "YES" : "NO");
            }
        }
        Console.Write(output);
    }

    private class DisjointSet
    {
        private int[] parents;
        private int[] ranks;

        public DisjointSet(int n)
        {
            // MakeSet
            int length = n + 1;

            parents = new int[length];
            for (int i = 0; i < parents.Length; ++i)
            {
                parents[i] = i;
            }

            ranks = new int[length];
            for (int i = 0; i < ranks.Length; ++i)
            {
                ranks[i] = 1;
            }
        }

        public int Find(int x)
        {
            int parent = parents[x];

            if (x != parent)
            {
                // 경로 압축
                return parents[x] = Find(parent);
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

            int aSetRepresentativeRank = ranks[aSetRepresentative];
            int bSetRepresentativeRank = ranks[bSetRepresentative];

            if (aSetRepresentativeRank > bSetRepresentativeRank)
            {
                parents[bSetRepresentative] = aSetRepresentative;
            }
            else if (aSetRepresentative < bSetRepresentativeRank)
            {
                parents[aSetRepresentative] = bSetRepresentative;
            }
            else
            {
                parents[bSetRepresentative] = aSetRepresentative;
                // 랭크는 대표 원소만 업데이트하면 됩니다.
                ++ranks[aSetRepresentative];
            }

            parents[Find(a)] = Find(b);
        }
    }
}