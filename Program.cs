using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        // length = 2
        // element = [1, 10^5]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int q = tokens[1];

        int[] canvas = new int[n + 1];

        SortedSet<int> set = new();
        for (int i = 1; i < canvas.Length; ++i) // max tc = 10^5
        {
            set.Add(i);
        }
        
        for (int i = 0; i < q; ++i) // max tc = 10^5
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [1, n] = [1, 10^5]
            int b = tokens[1]; // [1, n] = [1, 10^5]
            int x = tokens[2]; // [1, 10^9]

            while (true)
            {
                SortedSet<int> subset = set.GetViewBetween(a, b);
                if (subset.Count < 1)
                    break;

                int index = subset.Min;
                canvas[index] = x;
                subset.Remove(index);
            }
        }
        
        StringBuilder sb = new();
        for (int i = 1; i < canvas.Length; ++i) // max tc = 10^5
        {
            sb.Append($"{canvas[i]} ");
        }
        Console.Write(sb);
    }
}