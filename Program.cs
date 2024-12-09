internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // 2 ≤ n ≤ 10
        int s = tokens[1]; // 1 ≤ s
        int r = tokens[2]; // r ≤ n

        int[] kayaks = new int[n];
        for (int i = 0; i < kayaks.Length; ++i) // max tc = 10
        {
            kayaks[i] = 1;
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < s; ++i) // max tc = 10
        {
            --kayaks[tokens[i] - 1];
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < r; ++i) // max tc = 10
        {
            ++kayaks[tokens[i] - 1];
        }

        int output = 0;
        for (int i = 0; i < kayaks.Length; ++i) // max tc = 10
        {
            int leftIndex = i - 1;
            if (kayaks[i] > 1 && leftIndex > -1 && kayaks[leftIndex] < 1)
            {
                ++kayaks[leftIndex];
                --kayaks[i];
                --output;
            }

            // we need to check the condition 'kayaks[i] > 1' for each twice
            int rightIndex = i + 1;
            if (kayaks[i] > 1 && rightIndex < kayaks.Length && kayaks[rightIndex] < 1)
            {
                ++kayaks[rightIndex];
                --kayaks[i];
            }
            
            if (kayaks[i] < 1)
            {
                ++output;
            }
        }
        Console.Write(output);
    }
}