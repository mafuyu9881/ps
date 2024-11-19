internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] steppingStones = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        int departureIndex = tokens[0] - 1;
        int arrivalIndex = tokens[1] - 1;
        
        const int InvalidMovedCount = -1;

        Queue<int> visitingIndices = new();
        int[] movedCounts = new int[n];
        // of course, this loop takes more time but it also gives consistency for the whole code
        // max of n is 10,000 in this problem so, it's safe enough from the time limit
        for (int i = 0; i < n; ++i)
        {
            movedCounts[i] = InvalidMovedCount;
        }

        visitingIndices.Enqueue(departureIndex);
        movedCounts[departureIndex] = 0;

        while (visitingIndices.Count > 0)
        {
            int currIndex = visitingIndices.Dequeue();
            int steppingStone = steppingStones[currIndex];

            for (int nextIndex = 0; nextIndex < n; ++nextIndex)
            {
                // we can omit this condition
                //if (nextIndex == currIndex)
                //    continue;

                if ((nextIndex - currIndex) % steppingStone != 0)
                    continue;

                ref int nextmovedCountRef = ref movedCounts[nextIndex];
                if (nextmovedCountRef != InvalidMovedCount)
                    continue;

                visitingIndices.Enqueue(nextIndex);
                nextmovedCountRef = movedCounts[currIndex] + 1;
            }
        }
        Console.Write(movedCounts[arrivalIndex]);
    }
}