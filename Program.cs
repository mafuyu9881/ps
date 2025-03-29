using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 5 * 10^5]

        // length = [1, n] = [1, 5 * 10^5]
        // element = [1, 10^18]
        long[] inks = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long[] viscosities = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        StringBuilder sb = new();
        for (int i = 0; i < inks.Length; ++i)
        {
            int lo = (i + 1) - 1;
            int hi = (viscosities.Length - 1) + 1;
            while (lo < hi - 1)
            {
                int mid = (lo + hi) / 2;

                if (inks[i] < viscosities[mid])
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            sb.Append($"{lo - (i + 1) + 1} ");
        }
        Console.Write(sb);
    }
}