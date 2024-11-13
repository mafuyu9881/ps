using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int serverRackMapLength = n * n;
        int[] serverRackMap = new int[serverRackMapLength];

        BigInteger allComputers = 0;
        for (int row = 0; row < n; ++row)
        {
            int[] serverRackLine = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col)
            {
                int serverRack = serverRackLine[col];
                allComputers += serverRack;
                serverRackMap[n * row + col] = serverRack;
            }
        }

        int output = 0;
        int low = 0;
        int high = serverRackMap.Max();
        while (low <= high)
        {
            int mid = (low + high) / 2;

            BigInteger coldComputers = 0;
            for (int i = 0; i < serverRackMapLength; ++i)
            {
                coldComputers += Math.Min(mid, serverRackMap[i]);
            }

            if (coldComputers * 2 < allComputers)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
                output = mid;
            }
        }
        Console.Write(output);
    }
}