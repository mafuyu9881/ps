using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        SortedDictionary<long, int> dp = new();
        LinkedList<long> waitings = new();

        dp.Add(a, 1);
        waitings.AddLast(a);
        while (waitings.Count > 0)
        {
            long basis = waitings.First!.Value;
            waitings.RemoveFirst();

            int newComputings = dp[basis] + 1;

            long doubled = basis * 2;
            if (doubled <= b)
            {
                if (dp.ContainsKey(doubled) == false)
                {
                    dp.Add(doubled, newComputings);
                    waitings.AddLast(doubled);
                }
                else if (newComputings < dp[doubled])
                {
                    dp[doubled] = newComputings;
                    waitings.AddLast(doubled);
                }
            }

            long attached = basis * 10 + 1;
            if (attached <= b)
            {
                if (dp.ContainsKey(attached) == false)
                {
                    dp.Add(attached, newComputings);
                    waitings.AddLast(attached);
                }
                else if (newComputings < dp[attached])
                {
                    dp[doubled] = newComputings;
                    waitings.AddLast(attached);
                }
            }
        }

        string output = "";
        if (dp.ContainsKey(b))
        {
            output = $"{dp[b]}";
        }
        else
        {
            output = "-1";
        }
        Console.Write(output);
    }
}