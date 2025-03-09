using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = integerTokens[0]; // [1, 2 * 10^5]
        int m = integerTokens[1]; // [1, 2 * 10^5]

        SortedSet<string> ss = new();
        for (int i = 0; i < n; ++i) // max tc = 2 * 10^5
        {
            ss.Add(Console.ReadLine()!); // max tc = log2(2 * 10^5) = 17.xxx
        }

        StringBuilder sb = new();
        for (int i = 0; i < m; ++i) // max tc = 2 * 10^5
        {
            string[] stringTokens = Console.ReadLine()!.Split(',');

            for (int j = 0; j < stringTokens.Length; ++j) // max tc = 10
            {
                string keyword = stringTokens[j];

                if (ss.Contains(keyword) == false) // max tc = 17.xxx
                    continue;

                ss.Remove(keyword); // max tc = 17.xxx
            }

            sb.AppendLine($"{ss.Count}");
        }
        Console.Write(sb);
    }
}