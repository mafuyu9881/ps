using System.Text;

internal class Program
{


    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0];
            int m = tokens[1];

            //int cases = 1; // 0 < N ≤ M < 30
            //for (int j = 0; j < n; ++j)
            //{
            //    cases *= (m - j) - (n - j - 1);
            //}
            int cases = 0;
            ComputeCases(ref cases, n, m, 0, 0);
            output.AppendLine($"{cases}");
        }
        Console.Write(output);
    }

    private static void ComputeCases(ref int cases, int n, int m, int lastEastOccupiedSiteCount, int currWestSiteIndex)
    {
        for (int occupiableEastSiteIndex = lastEastOccupiedSiteCount;
             occupiableEastSiteIndex < m - (n - currWestSiteIndex - 1);
             ++occupiableEastSiteIndex)
        {
            if (currWestSiteIndex < n - 1)
            {
                ComputeCases(ref cases, n, m, lastEastOccupiedSiteCount + 1, currWestSiteIndex + 1);
            }
            else
            {
                ++cases;
            }
        }
    }
}