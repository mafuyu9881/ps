// 0 ≤ (수직선 상의 집의 좌표) ≤ 1,000,000,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int c = tokens[1];
        
        int[] coordinates = new int[n];
        for (int i = 0; i < n; ++i)
        {
            coordinates[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(coordinates);

        int output = 0;
        int left = 1;
        int right = 1000000000;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (Validation(c, coordinates, mid))
            {
                output = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        Console.Write(output);
    }

    private static bool Validation(int installableRouters, int[] coordinates, int leastRouterDistance)
    {
        int prevCoord = coordinates[0];
        --installableRouters;

        for (int i = 1; i < coordinates.Length; ++i)
        {
            int currCoord = coordinates[i];

            if (currCoord - prevCoord >= leastRouterDistance)
            {
                --installableRouters;
                prevCoord = currCoord;
            }
        }

        return installableRouters < 1;
    }
}