using System.Text;

internal class Program
{
    private class DisjointSet
    {
        private int[] parents;

        public DisjointSet(int n)
        {
            // MakeSet
            parents = new int[n + 1];
            for (int i = 0; i < parents.Length; ++i)
            {
                parents[i] = i;
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
            parents[Find(a)] = Find(b);
        }
    }

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
}