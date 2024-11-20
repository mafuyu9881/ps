internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 2 ≤ n ≤ 500
        int extendedN = n + 1;

        int m = int.Parse(Console.ReadLine()!); // 1 ≤ m ≤ 10000

        LinkedList<int>[] adjList = new LinkedList<int>[extendedN];
        for (int i = 0; i < adjList.Length; ++i)
        {
            adjList[i] = new();
        }

        for (int i = 0; i < m; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];

            adjList[a].AddLast(b);
            adjList[b].AddLast(a);
        }

        const int InvalidDistance = -1;

        Queue<int> visitingQueue = new();
        int[] distanceTable = new int[extendedN];
        for (int i = 0; i < distanceTable.Length; ++i)
        {
            distanceTable[i] = InvalidDistance;
        }

        int s = 1;
        visitingQueue.Enqueue(s);
        distanceTable[s] = 0;

        int invitations = 0;
        while (visitingQueue.Count > 0)
        {
            int srcV = visitingQueue.Dequeue();

            int adjVDistance = distanceTable[srcV] + 1;
            if (adjVDistance > 2)
                continue;

            var adjs = adjList[srcV];
            for (var node = adjs.First; node != null; node = node.Next)
            {
                int adjV = node.Value;
                if (distanceTable[adjV] != InvalidDistance)
                    continue;
                
                visitingQueue.Enqueue(adjV);
                distanceTable[adjV] = adjVDistance;

                ++invitations;
            }
        }
        Console.Write(invitations);
    }
}