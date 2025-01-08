internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int peopleCount = tokens[0]; // [1, 50]
        int partyCount = tokens[1]; // [1, 50]

        DisjointSet ds = new(peopleCount);

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // [1, 50]
        LinkedList<int> witnesses = new();
        for (int i = 1; i < tokens.Length; ++i)
        {
            int witness = tokens[i];
            ds.Union(tokens[1], witness);
            witnesses.AddLast(witness);
        }

        LinkedList<LinkedList<int>> parties = new();
        for (int i = 0; i < partyCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // [2, 50]
            LinkedList<int> party = new();
            for (int j = 1; j < tokens.Length; ++j)
            {
                int member = tokens[j];
                ds.Union(tokens[1], member);
                party.AddLast(member);
            }
            parties.AddLast(party);
        }

        int output = 0;
        for (var partyNode = parties.First; partyNode != null; partyNode = partyNode.Next)
        {
            if (CanParticipate(ds, witnesses, partyNode.Value))
            {
                ++output;
            }
        }
        Console.Write(output);
    }

    private static bool CanParticipate(DisjointSet ds, LinkedList<int> witnesses, LinkedList<int> party)
    {
        if (witnesses.Count < 1)
            return true;

        int witness = witnesses.First!.Value;

        for (var node = party.First; node != null; node = node.Next)
        {
            if (ds.Find(witness) == ds.Find(node.Value))
            {
                return false;
            }
        }

        return true;
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