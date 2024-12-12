internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 100,000

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(tokens);
        Array.Reverse(tokens);

        LinkedList<int> saplings = new();
        for (int i = 0; i < tokens.Length; ++i)
        {
            saplings.AddLast(tokens[i]);
        }

        int output = 1; // the day we bought a seed was day 1
        int remainTime = saplings.First!.Value;
        saplings.RemoveFirst();
        while (remainTime > 0)
        {
            --remainTime;

            if (saplings.Count > 0)
            {
                remainTime = Math.Max(remainTime, saplings.First.Value);
                saplings.RemoveFirst();
            }

            ++output;
        }
        Console.Write(output + 1); // invite foreman on the next day
    }
}