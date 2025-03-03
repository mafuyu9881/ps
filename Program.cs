using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // length = [2, 500]
        string token = Console.ReadLine()!;

        LinkedList<char> ll = new();
        int zeros = 0;
        int ones = 0;
        for (int i = 0; i < token.Length; ++i) // max tc = 500
        {
            char c = token[i];

            if (c == '0')
            {
                ++zeros;
            }
            else
            {
                ++ones;
            }

            ll.AddLast(c);
        }

        zeros /= 2;
        ones /= 2;

        LinkedListNode<char>? lln = null;

        lln = ll.Last!;
        while (zeros > 0)
        {
            var prevLLN = lln.Previous!;

            if (lln.Value == '0')
            {
                ll.Remove(lln);
                --zeros;
            }

            lln = prevLLN;
        }

        lln = ll.First!;
        while (ones > 0)
        {
            var nextLLN = lln.Next!;

            if (lln.Value == '1')
            {
                ll.Remove(lln);
                --ones;
            }
            
            lln = nextLLN;
        }

        StringBuilder sb = new();
        for (lln = ll.First!; lln != null; lln = lln.Next)
        {
            sb.Append(lln.Value);
        }
        Console.Write(sb);
    }
}