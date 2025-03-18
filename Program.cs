internal class Program
{
    private static void Main(string[] args)
    {
        // length = 2
        // element = [1, 300'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int k = tokens[1];

        // length = [1, 300'000]
        // element = [-10^8, 10^8]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        long[] prefixSum = new long[n];
        prefixSum[0] = tokens[0];
        for (int i = 1; i < prefixSum.Length; ++i) // max tc = 300'000 - 1
        {
            prefixSum[i] = prefixSum[i - 1] + tokens[i];
        }
        Array.Sort(prefixSum, (x, y) => y.CompareTo(x));
        
        long sum = 0;
        for (int i = 0; i < k; ++i)
        {
            sum += prefixSum[i];
        }
        Console.Write(sum);
    }
}