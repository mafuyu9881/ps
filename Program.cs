using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000]
        
        // length = [1, 1'000]
        // element = [1, 1'000'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] prefixSum = new int[tokens.Length];
        for (int i = 0; i < prefixSum.Length; ++i) // max tc = 1'000
        {
            prefixSum[i] = tokens[i];

            if (i > 0)
            {
                prefixSum[i] += prefixSum[i - 1];
            }
        }

        StringBuilder sb = new();
        for (int i = 1; i <= n; ++i) // max tc = 1'000
        {
            
        }
        Console.Write(sb);
    }
}