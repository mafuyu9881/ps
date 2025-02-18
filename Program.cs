using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine()!); // [1, 10]

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = [2^1, 2^10] = [2, 1'024]

        LinkedList<int>[] nodes = new LinkedList<int>[k];
        for (int i = 0; i < nodes.Length; ++i)
        {
            nodes[i] = new();
        }

        Solve(nodes, tokens, 0);

        StringBuilder sb = new();
        for (int i = 0; i < nodes.Length; ++i)
        {
            for (var lln = nodes[i].First; lln != null; lln = lln.Next)
            {
                sb.Append($"{lln.Value} ");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }

    private static void Solve(LinkedList<int>[] nodes, Span<int> tokens, int currDepth)
    {
        int tokensLength = tokens.Length;
        if (tokensLength < 1)
            return;

        int mid = tokensLength / 2;

        nodes[currDepth].AddLast(tokens[mid]);

        int nextDepth = currDepth + 1;
        Solve(nodes, tokens.Slice(0, mid), nextDepth);
        Solve(nodes, tokens.Slice(mid + 1), nextDepth);
    }
}