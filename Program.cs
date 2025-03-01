internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 200'000]
        int m = tokens[1]; // [1, 1'000'000'000]

        // length = [1, 200'000]
        // element = [0, 1'000'000'000]
        int[] complaints = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        long sum = 0;
        for (int i = 0; i < complaints.Length; ++i) // max tc = 200'000
        {
            sum += complaints[i];
        }

        Array.Sort(complaints); // max tc = 200'000 * log2(200'000) = 200'000 * 17.xxx

        int eggplants = 0;
        for (int i = complaints.Length - 1; i >= 0; --i) // max tc = 200'000
        {
            if (sum < m)
                break;

            sum -= complaints[i] * 2;
            ++eggplants;
        }
        Console.Write(eggplants);
    }
}