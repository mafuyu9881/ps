using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            string? line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;

            int x = int.Parse(line) * 10000000; // 1cm = 10'000'000nm

            int n = int.Parse(Console.ReadLine()!); // [0, 1'000'000]

            int[] legos = new int[n]; // [1, 100'000'000]
            for (int i = 0; i < n; ++i) // max tc = 1'000'000
            {
                legos[i] = int.Parse(Console.ReadLine()!);
            }
            Array.Sort(legos);

            (int lego1, int lego2)? answer = null;
            {
                int lo = 0;
                int hi = n - 1;

                while (lo < hi)
                {
                    int lego1 = legos[lo];
                    int lego2 = legos[hi];
                    int sum = lego1 + lego2;

                    if (sum < x)
                    {
                        ++lo;
                    }
                    else if (sum > x)
                    {
                        --hi;
                    }
                    else
                    {
                        answer = (lego1, lego2);
                        break;
                    }
                }
            }

            if (answer.HasValue)
            {
                sb.AppendLine($"yes {answer.Value.lego1} {answer.Value.lego2}");
            }
            else
            {
                sb.AppendLine("danger");
            }
        }
        Console.Write(sb);
    }
}