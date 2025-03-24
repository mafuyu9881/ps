using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2^2 - 1, 2^17 - 1] = [4 - 1, 131'072 - 1]

        // max length = 131'072 - 1
        // element = -1, [0, 10^9]
        int[] values = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int x = int.Parse(Console.ReadLine()!); // [0, 10^9]

        for (int i = 0; i < values.Length; ++i) // max tc = 131'072 - 1
        {
            if (values[i] == -1)
            {
                values[i] = x;
                break;
            }
        }

        Array.Sort(values);

        StringBuilder sb = new();
        PostOrderTraversal(sb, values);
        Console.Write(sb);
    }

    private static void PostOrderTraversal(StringBuilder sb, Span<int> span)
    {
        if (span.Length <= 3) // span's length can't be less than 3 (min n = 2^2 - 1 = 3)
        {
            sb.Append($"{span[0]} ");
            sb.Append($"{span[2]} ");
            sb.Append($"{span[1]} ");
        }
        else
        {
            PostOrderTraversal(sb, span.Slice(0, span.Length / 2));
            PostOrderTraversal(sb, span.Slice(span.Length / 2 + 1));
            sb.Append($"{span[span.Length / 2]} ");
        }
    }
}