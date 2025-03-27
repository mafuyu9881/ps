internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 500'000]

        int[] requireds = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // [1, 101]

        int stick = requireds.Sum(); // [1, 50'500'000]

        long cost = 0;
        Array.Sort(requireds);
        for (int i = 0; i < requireds.Length; ++i)
        {
            int required = requireds[i];

            stick -= required;

            cost += stick * (long)required;
        }
        Console.Write(cost);
    }
}