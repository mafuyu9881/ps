internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int users = tokens[0]; // 2 ≤ n ≤ 100
        int usersExt = users + 1;
        int relations = tokens[1]; // 1 ≤ m ≤ 5,000

        LinkedList<int>[] adjList = new LinkedList<int>[usersExt];
        for (int i = 0; i < relations; ++i) // max = 5,000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int v0 = tokens[0];
            int v1 = tokens[1];

            if (adjList[v0] == null)
            {
                adjList[v0] = new();
            }
            adjList[v0].AddLast(v1);

            if (adjList[v1] == null)
            {
                adjList[v1] = new();
            }
            adjList[v1].AddLast(v0);
        }

        const int InvalidDistance = -1;
        const int InvalidKevinBacon = -1;
        
        int minKevinBacon = InvalidKevinBacon;
        PriorityQueue<int, int> minKevinBaconUsers = new();
        for (int startV = 1; startV < usersExt; ++startV) // max = 100
        {
            int[] distances = new int[usersExt];
            for (int i = 0; i < distances.Length; ++i)
            {
                distances[i] = InvalidDistance;
            }
            Queue<int> q = new();

            distances[startV] = 0;
            q.Enqueue(startV);

            while (q.Count > 0)
            {
                int v = q.Dequeue();

                var adjs = adjList[v];
                for (var node = adjs.First; node != null; node = node.Next)
                {
                    int adjV = node.Value;
                    if (distances[adjV] != InvalidDistance)
                        continue;

                    distances[adjV] = distances[v] + 1;
                    q.Enqueue(adjV);
                }
            }

            int kevinBacon = 0;
            for (int i = 1; i < distances.Length; ++i) // max = 100
            {
                kevinBacon += distances[i];
            }

            if (minKevinBacon == InvalidKevinBacon || kevinBacon < minKevinBacon)
            {
                minKevinBacon = kevinBacon;
                minKevinBaconUsers.Clear();
            }
            minKevinBaconUsers.Enqueue(startV, startV);
        }
        Console.Write(minKevinBaconUsers.Dequeue());
    }
}