using System.Net.Http.Headers;

public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int r = tokens[0];
        int c = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];

        int arrayLength = n + 1;

        const int Invalid = -1;
        int[] minRow = new int[arrayLength];
        int[] maxRow = new int[arrayLength];
        int[] minCol = new int[arrayLength];
        int[] maxCol = new int[arrayLength];

        for (int i = 0; i < arrayLength; ++i)
        {
            minRow[i] = Invalid;
            maxRow[i] = Invalid;
            minCol[i] = Invalid;
            maxCol[i] = Invalid;
        }

        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int v = tokens[1];
            int h = tokens[2];

            int oldMinRow = minRow[a];
            if (oldMinRow == Invalid || v < oldMinRow)
                minRow[a] = v;

            int oldMaxRow = maxRow[a];
            if (oldMaxRow == Invalid || v > oldMaxRow)
                maxRow[a] = v;

            int oldMinCol = minCol[a];
            if (oldMinCol == Invalid || h < oldMinCol)
                minCol[a] = h;

            int oldMaxCol = maxCol[a];
            if (oldMaxCol == Invalid || h > oldMaxCol)
                maxCol[a] = h;
        }

        int bestId = 0;
        long bestArea = Invalid;
        
        for (int a = 1; a <= n; ++a)
        {
            if (minRow[a] == Invalid)
                continue;

            long height = (long)maxRow[a] - minRow[a] + 1;
            long width = (long)maxCol[a] - minCol[a] + 1;
            long area = height * width;

            if ((bestArea == Invalid) ||
                (area > bestArea) ||
                (area == bestArea && a < bestId))
            {
                bestArea = area;
                bestId = a;
            }
        }

        Console.Write($"{bestId} {bestArea}");
    }
}