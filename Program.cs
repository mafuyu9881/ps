internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int k = tokens[1];

        int[] depths = new int[k + 1];
        Queue<int> visitingQueue = new();
        visitingQueue.Enqueue(a);
        while (visitingQueue.Count > 0)
        {
            int ai = visitingQueue.Dequeue(); // which means the ith element in integer A's sequence

            int aiVisitedTurns = depths[ai];

            int next = ai + 1;
            if (next <= k && depths[next] < 1)
            {
                visitingQueue.Enqueue(next);
                depths[next] = aiVisitedTurns + 1;
            }
            int twice = ai * 2;
            if (twice <= k && depths[twice] < 1)
            {
                visitingQueue.Enqueue(twice);
                depths[twice] = aiVisitedTurns + 1;
            }
        }
        Console.Write(depths[k]);
    }
}