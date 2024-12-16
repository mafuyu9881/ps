internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 50,000
        const int Infinity = 5;
        int minimumSquareCount = Infinity;
        ComputeMinimumSquareCount(ref minimumSquareCount, n, 0);
        Console.Write(minimumSquareCount);
    }

    private static void ComputeMinimumSquareCount(ref int minimumSquareCount, int remainN, int prevSquareCount)
    {
        int sqrtRemainN = (int)Math.Sqrt(remainN);
        int currSquareCount = prevSquareCount + 1;

        for (int i = sqrtRemainN; i > sqrtRemainN / 2; --i)
        {
            int newRemainN = remainN - i * i;

            if (newRemainN == 0)
            {
                minimumSquareCount = Math.Min(minimumSquareCount, currSquareCount);
                return;
            }
            else if (currSquareCount < 4)
            {
                ComputeMinimumSquareCount(ref minimumSquareCount, newRemainN, currSquareCount);
            }
        }
    }
}