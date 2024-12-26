using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string p = Console.ReadLine()!;
            int n = int.Parse(Console.ReadLine()!);
            string[] arr = Console.ReadLine()!.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
            LinkedList<int> llist = new();
            for (int j = 0; j < arr.Length; ++j)
            {
                llist.AddLast(int.Parse(arr[j]));
            }
            output.AppendLine(Proceed(p, llist));
        }
        Console.Write(output);
    }

    private static string Proceed(string p, LinkedList<int> llist)
    {
        bool reversed = false;
        for (int j = 0; j < p.Length; ++j)
        {
            if (p[j] == 'R')
            {
                reversed = !reversed;
            }
            else // if (p[j] == 'D')
            {
                if (llist.Count < 1)
                {
                    return "error";
                }

                if (reversed)
                {
                    llist.RemoveLast();
                }
                else
                {
                    llist.RemoveFirst();
                }
            }
        }

        StringBuilder output = new();
        output.Append('[');
        if (reversed)
        {
            for (var node = llist.Last; node != null; node = node.Previous)
            {
                output.Append(node.Value);
                if (node != llist.First)
                {
                    output.Append(',');
                }
            }
        }
        else
        {
            for (var node = llist.First; node != null; node = node.Next)
            {
                output.Append(node.Value);
                if (node != llist.Last)
                {
                    output.Append(',');
                }
            }
        }
        output.Append(']');
        return output.ToString();
    }
}