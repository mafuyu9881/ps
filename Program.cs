internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int peopleCount = tokens[0];
        int partyCount = tokens[1];

        DisjointSet ds = new(peopleCount);

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int witnessCount = tokens[0];
        LinkedList<int> witnesses = new();
        for (int i = 1; i < tokens.Length; ++i)
        {
            int witness = tokens[i];

            ds.Union(0, witness);
            witnesses.AddLast(witness);
        }

        for (int i = 0; i < partyCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int memberCount = tokens[0];
            for (int j = 1; j < tokens.Length; ++j)
            {

            }
        }
    }

    private class DisjointSet
    {
        private int[] parents;
        private int[] ranks;
        
        public DisjointSet(int n)
        {
            int count = n + 1;

            parents = new int[count];
            for (int i = 0; i < parents.Length; ++i)
            {
                parents[i] = i;
            }

            ranks = new int[count];
        }

        // find the representative of the set including x
        public int Find(int x)
        {
            int parent = parents[x];

            if (x != parent)
            {
                // return Find(parent); // find without compressing path
                return parents[x] = Find(parent); // find with compressing path
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

            int aSetRank = ranks[aSetRepresentative];
            int bSetRank = ranks[bSetRepresentative];
            if (aSetRank > bSetRank)
            {
                parents[bSetRepresentative] = aSetRepresentative;
            }
            else if (aSetRank < bSetRank)
            {
                parents[aSetRepresentative] = bSetRepresentative;
            }
            else
            {
                parents[bSetRepresentative] = aSetRepresentative;
                ++ranks[aSetRepresentative];
            }

            parents[Find(a)] = Find(b); // compress path
        }
    }
}