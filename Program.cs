using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] seats = new int[1000000 + 1];

        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            // length = 2
            // element = [1, 1'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int s = tokens[0];
            int e = tokens[1];

            ++seats[s];

            int l = e + 1; // left time
            if (l < seats.Length)
            {
                --seats[l];
            }
        }

        for (int i = 1; i < seats.Length; ++i) // tc = 1'000'000
        {
            seats[i] += seats[i - 1];
        }

        int q = int.Parse(Console.ReadLine()!); // [1, 100'000]
        
        int[] viewingTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        StringBuilder sb = new();
        for (int i = 0; i < viewingTimes.Length; ++i) // max tc = 100'000
        {
            sb.AppendLine($"{seats[viewingTimes[i]]}");
        }
        Console.Write(sb);
    }
}