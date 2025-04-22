internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 5'000]
        int k = tokens[1]; // [1, 1'000'000'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] weights = new int[tokens.Length];
        for (int i = 0; i < weights.Length; ++i)
        {
            weights[i] = tokens[i];
        }
        Array.Sort(weights);

        int answer = 0;
        {
            int i = 0;
            int j = weights.Length - 1;
            while (i < j)
            {
                if (weights[i] + weights[j] > k)
                {
                    --j;
                }
                else
                {
                    ++answer;
                    ++i;
                    --j;
                }
            }
        }
        Console.Write(answer);
    }
}