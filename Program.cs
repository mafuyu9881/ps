// 1 ≤ K ≤ N ≤ 1,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        LinkedList<int> list = new();
        for (int i = 0; i < n; ++i)
        {
            list.AddLast(i + 1);
        }

        StringBuilder output = new("<");
        LinkedListNode<int> node = list.First!;
        int steps = k - 1;
        while (true)
        {
            for (int i = 0; i < steps; ++i)
            {
                node = (node.Next ?? list.First)!;
            }

            LinkedListNode<int> next_node = (node.Next ?? list.First)!;

            output.Append(node.Value);
            list.Remove(node);

            node = next_node;

            if (list.Count > 0)
            {
                output.Append(", ");
            }
            else
            {
                break;
            }
        }
        output.Append(">");
        Console.Write(output);
    }
}