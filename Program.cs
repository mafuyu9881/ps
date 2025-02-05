using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [?, 50]

        LinkedList<int>[] adjList = new LinkedList<int>[n + 1];
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [1, 50]
            int b = tokens[1]; // [1, 50]

            if (a == -1 && b == a)
                break;

            if (adjList[a] == null)
            {
                adjList[a] = new();
            }
            if (adjList[b] == null)
            {
                adjList[b] = new();
            }

            adjList[a].AddLast(b);
            adjList[b].AddLast(a);
        }

        const int InvalidDistance = -1;

        int mainScore = InvalidDistance;
        PriorityQueue<int, int> candidates = new();
        for (int beginV = 1; beginV <= n; ++beginV) // max tc = 50
        {
            int[] distances = new int[n + 1];
            for (int i = 0; i < distances.Length; ++i) // max tc = 51
            {
                distances[i] = InvalidDistance;
            }
            Queue<int> q = new();
            
            distances[beginV] = 0;
            q.Enqueue(beginV);
            
            int subScore = InvalidDistance;
            while (q.Count > 0) // max tc = 50 * (50 - 1) / 2 = 1'225
            {
                int v = q.Dequeue();

                int newDistance = distances[v] + 1;

                var adjs = adjList[v];
                for (var node = adjs.First; node != null; node = node.Next) // max tc = 49
                {
                    int adjV = node.Value;

                    int oldDistance = distances[adjV];
                    if (oldDistance != InvalidDistance &&
                        oldDistance <= newDistance)
                        continue;

                    distances[adjV] = newDistance;
                    q.Enqueue(adjV);

                    if (subScore != InvalidDistance &&
                        subScore >= newDistance)
                        continue;

                    subScore = newDistance;
                }
            }

            if (mainScore == InvalidDistance || mainScore > subScore)
            {
                mainScore = subScore;
                candidates.Clear();
            }

            if (mainScore == subScore)
            {
                candidates.Enqueue(beginV, beginV); // max tc = log2(50) = 5.xxx
            }
        }

        StringBuilder sb = new();
        sb.AppendLine($"{mainScore} {candidates.Count}");
        while (candidates.Count > 0) // max tc = 50
        {
            sb.Append($"{candidates.Dequeue()} ");
        }
        Console.Write(sb);
    }
}