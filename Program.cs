internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        // I guess it's better to use extended arrays rather than adjusted input indices
        int extendedN = n + 1;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int e = tokens[1];

        int m = int.Parse(Console.ReadLine()!);
        LinkedList<int>[] adjList = new LinkedList<int>[extendedN];
        for (int i = 0; i < extendedN; ++i) // max tc = 100
        {
            adjList[i] = new();
        }
        for (int i = 0; i < m; ++i) // max tc < 100 (maybe?)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            adjList[a].AddLast(b);
            adjList[b].AddLast(a);
        }
        
        const int InvalidDistance = -1;

        Queue<int> visitingQueue = new();
        int[] distanceTable = new int[extendedN];
        for (int i = 0; i < extendedN; ++i) // max tc = 100
        {
            distanceTable[i] = InvalidDistance;
        }

        visitingQueue.Enqueue(s);
        distanceTable[s] = 0;

        while (visitingQueue.Count > 0)
        {
            int visitedIndex = visitingQueue.Dequeue();
            int visitedDistance = distanceTable[visitedIndex];

            var adjs = adjList[visitedIndex];
            for (var node = adjs.First; node != null; node = node.Next)
            {
                int adjIndex = node.Value;

                if (distanceTable[adjIndex] != InvalidDistance)
                    continue;

                visitingQueue.Enqueue(adjIndex);
                distanceTable[adjIndex] = visitedDistance + 1;
            }
        }
        
        Console.Write(distanceTable[e]);
    }
}