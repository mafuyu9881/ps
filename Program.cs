using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        // maybe we can treat the node number as if 1 is added to it
        // to avoid setting all parents' elements
        // with -1 in a large iteration
        // but not in this time
        const int InvalidParent = -1;

        int[] parents = new int[200000];
        for (int i = 0; i < parents.Length; ++i) // tc = 200'000
        {
            parents[i] = InvalidParent;
        }
        
        int vertices = 1;
        int[] path = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 1; i < path.Length; ++i) // max tc = 200'000
        {
            int v = path[i];

            if (v == path[0])
                continue;

            if (parents[v] != InvalidParent)
                continue;

            parents[v] = path[i - 1];
            ++vertices;
        }
        
        StringBuilder output = new();
        output.AppendLine($"{vertices}");
        for (int i = 0; i < vertices; ++i) // max tc = 200'000
        {
            output.Append($"{parents[i]} ");
        }
        Console.Write(output);
    }
}