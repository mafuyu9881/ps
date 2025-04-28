using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int g = int.Parse(Console.ReadLine()!); // [1, 100'000]

        List<int> list = new(50000);
        for (int i = 2; i * i - (i - 1) * (i - 1) <= g; ++i)
        {
            int lo = 1 - 1;
            int hi = (i - 1) + 1;
            while (lo < hi - 1)
            {
                int mid = (lo + hi) / 2;

                if (i * i - mid * mid >= g)
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }

            if (i * i - lo * lo == g)
            {
                list.Add(i);
            }
        }

        StringBuilder sb = new();
        if (list.Count < 1)
        {
            sb.AppendLine($"{-1}");
        }
        else
        {
            for (int i = 0; i < list.Count; ++i)
            {
            sb.AppendLine($"{list[i]}");
            }
        }
        Console.Write(sb);
    }
}