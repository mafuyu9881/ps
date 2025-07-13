class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] xs = new int[n];
        int[] ys = new int[n];
        for (int i = 0; i < n; ++i)
        {
            // length = 2
            // element = [-1'000'000, 1'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            xs[i] = tokens[0];
            ys[i] = tokens[1];
        }
        Array.Sort(xs);
        Array.Sort(ys);

        long xMinDiffSum = 0;
        long yMinDiffSum = 0;
        for (int i = 0; i < n; ++i)
        {
            xMinDiffSum += Math.Abs(xs[i] - xs[n / 2]);
            yMinDiffSum += Math.Abs(ys[i] - ys[n / 2]);
        }
        Console.Write(xMinDiffSum + yMinDiffSum);
    }
}