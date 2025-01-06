internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int src = tokens[0];
        int dst = tokens[1];
        
        const int InvalidSpentTime = -1;
        int[] spentTimes = new int[100001];
        for (int i = 0; i < spentTimes.Length; ++i)
        {
            spentTimes[i] = InvalidSpentTime;
        }
        Queue<int> visitingQueue = new();

        spentTimes[src] = 0;
        visitingQueue.Enqueue(src);
        while (visitingQueue.Count > 0)
        {
            int x = visitingQueue.Dequeue();

            // it's a bit of a burden to allocate heap memories but-
            // sometimes it needs a sacrifice for the tidy code.
            int[] adjXs = new int[] { x + 1, x - 1, x * 2 };
            int[] adjSpentTimes = new int[] { 1, 1, 0 };
            for (int i = 0; i < adjXs.Length; ++i)
            {
                int adjX = adjXs[i];
                if (adjX < 0 || adjX > spentTimes.Length - 1)
                    continue;

                int oldSpentTime = spentTimes[adjX];
                int newSpentTime = spentTimes[x] + adjSpentTimes[i];
                if (oldSpentTime != InvalidSpentTime && oldSpentTime <= newSpentTime)
                    continue;

                spentTimes[adjX] = newSpentTime;
                visitingQueue.Enqueue(adjX);
            }
        }
        
        Console.Write(spentTimes[dst]);
    }
}