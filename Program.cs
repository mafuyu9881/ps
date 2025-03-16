internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [?, ?]
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 20'000]
            int m = tokens[1]; // [1, 20'000]

            // length = [1, 20'000]
            // element = [1, ?]
            int[] aSizes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] bSizes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            // max tc = 20'000 * log2(20'000) = 20'000 * 14.xxx
            Array.Sort(aSizes);
            Array.Sort(bSizes);

            
        }
    }
}