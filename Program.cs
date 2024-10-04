// 시간 제한: 0.5초
// 메모리 제한: 512MB
// 1 ≤ N ≤ 15
// 0 ≤ r, c < 2^N

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int r = int.Parse(tokens[1]);
        int c = int.Parse(tokens[2]);

        int[] sqrtOfTwo = new int[n * 2 + 1];
        sqrtOfTwo[0] = 1;
        for (int i = 1; i < sqrtOfTwo.Length; ++i)
        {
            sqrtOfTwo[i] = sqrtOfTwo[i - 1] * 2;
        }

        Index2D objectiveIndex2D = new(r, c);
        int objectiveIndex1D = ConvertIndexTo1D(sqrtOfTwo[n], objectiveIndex2D);

        // 2^2n / 4 == 2^(2n-2)
        int temp = objectiveIndex1D / sqrtOfTwo[2 * n - 2];
    }

    private static int ConvertIndexTo1D(int width, Index2D index2D)
    {
        return index2D.row * width + index2D.col;
    }

    private static Index2D ConvertIndexTo2D(int width, int index1D)
    {
        return new(index1D / width, index1D % width);
    }
}

struct Index2D
{
    public int row;
    public int col;

    public Index2D(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}