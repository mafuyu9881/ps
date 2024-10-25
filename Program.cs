internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] distances = new int[n];
        int totalDistance = 0;
        for (int i = 0; i < n; ++i)
        {
            int distance = int.Parse(Console.ReadLine()!);
            distances[i] = distance;
            totalDistance += distance;
        }

        int[] prefixSum = new int[n];
        for (int i = 1; i < n; ++i)
        {
            prefixSum[i] = prefixSum[i - 1] + distances[i - 1];
        }

        const int InvalidDistance = -1;
        int maxDistance = InvalidDistance;
        for (int begin = 0; begin < n; ++begin)
        {
            for (int end = begin + 1; end < n; ++end)
            {
                int cwDistance = prefixSum[end] - prefixSum[begin];
                int ccwDistance = totalDistance - cwDistance;
                int distance = Math.Min(cwDistance, ccwDistance);

                if (maxDistance == InvalidDistance ||
                    maxDistance < distance)
                {
                    maxDistance = distance;
                }
            }
        }
        Console.Write(maxDistance);
    }
}