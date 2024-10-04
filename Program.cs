// 시간 제한: 0.5초
// 메모리 제한: 512MB
// 1 ≤ N ≤ 15
// 0 ≤ r, c < 2^N

internal class Program
{
    private static int[]? memoizedSqrtOfTwo = null;
    private static int memoizedIndex = -1;

    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int r = int.Parse(tokens[1]);
        int c = int.Parse(tokens[2]);
        
        memoizedSqrtOfTwo = new int[n + 1];

        Index2D objectiveIndex2D = new(r, c);

        Console.Write(ComputeVisitingTurn(SqrtOfTwo(n), objectiveIndex2D));
    }

    private static int ComputeVisitingTurn(int side, Index2D objectiveIndex2D)
    {
        int halfSide = side / 2;

        int objectiveRow = objectiveIndex2D.row;
        int objectiveCol = objectiveIndex2D.col;

        int quadrant = 0;

        Index2D adjustedObjectiveIndex2D = objectiveIndex2D;
        
        // 우상
        if (objectiveRow < halfSide && objectiveCol >= halfSide)
        {
            quadrant = 1;
            adjustedObjectiveIndex2D = new(objectiveRow, objectiveCol - halfSide);
        }
        // 좌하
        else if (objectiveRow >= halfSide && objectiveCol < halfSide)
        {
            quadrant = 2;
            adjustedObjectiveIndex2D = new(objectiveRow - halfSide, objectiveCol);
        }
        // 우하
        else if (objectiveRow >= halfSide && objectiveCol >= halfSide)
        {
            quadrant = 3;
            adjustedObjectiveIndex2D = new(objectiveRow - halfSide, objectiveCol - halfSide);
        }

        int sum = (side > 2) ? ComputeVisitingTurn(halfSide, adjustedObjectiveIndex2D) : 0;

        return sum + (quadrant * halfSide * halfSide);
    }

    // 배열의 범위를 벗어나는 값이 입력되지 않음이 전제됩니다.
    private static int SqrtOfTwo(int exponent)
    {
        while (memoizedIndex < exponent)
        {
            ++memoizedIndex;

            if (memoizedIndex < 1)
            {
                memoizedSqrtOfTwo![memoizedIndex] = 1;
            }
            else
            {
                memoizedSqrtOfTwo![memoizedIndex] = memoizedSqrtOfTwo[memoizedIndex - 1] * 2;
            }
        }

        return memoizedSqrtOfTwo![exponent];
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