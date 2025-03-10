internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [1, 10'000]
        int height = tokens[1]; // [1, 10'000]
        int n = tokens[2]; // [2, 10'000'000]

        double segmentedWidth = height / (double)n;

        double required = 0.0;
        for (int i = ((n & 1) == 1) ? 1 : 2; i < n; i += 2)
        {
            required += segmentedWidth * i;
        }
        required *= 2;

        Console.Write(required.ToString("F6"));
    }
}