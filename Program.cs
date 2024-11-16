using System.Text;

internal class Program
{
    private static int[]? _cutPoints = null;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        int l = tokens[2];

        _cutPoints = new int[m];
        for (int i = 0; i < m; ++i)
        {
            _cutPoints[i] = int.Parse(Console.ReadLine()!);
        }

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int leastSliceCount = int.Parse(Console.ReadLine()!);

            // 1 < L ≤ 4,000,000
            int low = 1 - 1;
            int high = 4000000 + 1;
            while (low < high - 1)
            {
                int mid = (low + high) / 2;
                
                if (Validation(l, leastSliceCount, mid))
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            output.AppendLine($"{low}");
        }
        Console.Write(output);
    }

    private static bool Validation(int l, int leastSliceCount, int leastSliceLength)
    {
        // never happens, but for preventing a compile warning
        if (_cutPoints == null)
            return false;

        int slicedCount = 0;
        int prevSlicePoint = 0;
        for (int j = 0; j < _cutPoints.Length; ++j)
        {
            int currSlicePoint = _cutPoints[j];
            int slicedLength = currSlicePoint - prevSlicePoint;

            if (slicedLength < leastSliceLength)
                continue;

            ++slicedCount;
            prevSlicePoint = currSlicePoint;
        }

        if (slicedCount > leastSliceCount)
            return true;

        if (slicedCount == leastSliceCount && l - prevSlicePoint >= leastSliceLength)
            return true;
        
        return false;
    }
}