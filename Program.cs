internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        (int enteringTime, int exitingTime)[] acts = new (int, int)[n];
        {
            for (int i = 0; i < n; ++i)
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                acts[i] = (tokens[0], tokens[1]);
            }
        }

        List<int> compressedCoords = new();
        {
            List<int> coords = new();
            for (int i = 0; i < acts.Length; ++i)
            {
                coords.Add(acts[i].enteringTime);
                coords.Add(acts[i].exitingTime);
            }
            coords.Sort();
            
            for (int i = 0; i < coords.Count; ++i)
            {
                int coord = coords[i];
                if ((i == 0) ||
                    (i > 0 && compressedCoords[compressedCoords.Count - 1] != coord))
                {
                    compressedCoords.Add(coord);
                }
            }
        }

        int[] prefixSum = new int[compressedCoords.Count];
        {
            for (int i = 0; i < acts.Length; ++i)
            {
                var act = acts[i];

                int enteringTime = act.enteringTime;
                int exitingTime = act.exitingTime;

                int compressedEnteringTime = compressedCoords.BinarySearch(enteringTime);
                int compressedExitingTime = compressedCoords.BinarySearch(exitingTime);

                prefixSum[compressedEnteringTime] += 1;
                prefixSum[compressedExitingTime] -= 1;
            }

            for (int i = 1; i < prefixSum.Length; ++i)
            {
                prefixSum[i] += prefixSum[i - 1];
            }
        }

        int maxCount = 0;
        int compressedEnteringTimeOnMaxCount = 0;
        {
            for (int i = 0; i < prefixSum.Length; ++i)
            {
                int count = prefixSum[i];

                if ((i == 0) ||
                    (i > 0 && count > maxCount))
                {
                    maxCount = count;
                    compressedEnteringTimeOnMaxCount = i;
                }
            }
        }

        int compressedExitingTimeOnMaxCount = 0;
        {
            for (int i = compressedEnteringTimeOnMaxCount; i <= prefixSum.Length; ++i)
            {
                if (i == prefixSum.Length || maxCount != prefixSum[i])
                {
                    compressedExitingTimeOnMaxCount = i;
                    break;
                }
            }
        }

        int enteringTimeOnMaxCount = compressedCoords[compressedEnteringTimeOnMaxCount];
        int exitingTimeOnMaxCount = compressedCoords[compressedExitingTimeOnMaxCount];

        Console.WriteLine(maxCount);
        Console.WriteLine($"{enteringTimeOnMaxCount} {exitingTimeOnMaxCount}");
    }
}