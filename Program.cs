class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int maxLength = 1;
        int increasingLength = 1;
        int decreasingLength = 1;
        for (int i = 1; i < n; ++i) // max tc = 100'000 - 1
        {
            if (sequence[i] >= sequence[i - 1])
            {
                ++increasingLength;
            }
            else
            {
                increasingLength = 1;
            }

            if (sequence[i] <= sequence[i - 1])
            {
                ++decreasingLength;
            }
            else
            {
                decreasingLength = 1;
            }

            maxLength = Math.Max(maxLength, Math.Max(increasingLength, decreasingLength));
        }
        Console.Write(maxLength);
    }
}