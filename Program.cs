using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            SortedSet<int> ss = new();
            for (int j = 0; j < tokens.Length; ++j) // max tc = 1'000'000
            {
                ss.Add(tokens[j]); // max tc = log2(1'000'000) = 19.xxx
            }

            int m = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int j = 0; j < tokens.Length; ++j) // max tc = 1'000'000
            {
                sb.AppendLine(ss.Contains(tokens[j]) ? "1" : "0"); // max tc = 19.xxx
            }
        }
        Console.Write(sb);
    }
}