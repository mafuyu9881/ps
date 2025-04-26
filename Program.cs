using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int lineCount = int.Parse(Console.ReadLine()!); // [2, 10]

        int[] tokens = null!;

        // length = [2, 10]
        // element = [1, 50]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] stationCounts = new int[lineCount + 1];
        for (int lineNumber = 1; lineNumber <= lineCount; ++lineNumber)
        {
            stationCounts[lineNumber] = tokens[lineNumber - 1];
        }

        int transferStationCount = int.Parse(Console.ReadLine()!); // [1, 250]

        LinkedList<(int line, int station)>[][] adjList = new LinkedList<(int, int)>[lineCount + 1][];
        for (int line = 1; line <= lineCount; ++line)
        {
            int stationCount = stationCounts[line];

            adjList[line] = new LinkedList<(int, int)>[stationCount + 1];
            for (int station = 1; station <= stationCount; ++station)
            {
                adjList[line][station] = new();

                if (station > 1)
                {
                    adjList[line][station].AddLast((line, station - 1));
                }

                if (station < stationCount)
                {
                    adjList[line][station].AddLast((line, station + 1));
                }
            }
        }

        for (int i = 0; i < transferStationCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int p1 = tokens[0];
            int p2 = tokens[1];
            int q1 = tokens[2];
            int q2 = tokens[3];
            adjList[p1][p2].AddLast((q1, q2));
            adjList[q1][q2].AddLast((p1, p2));
        }

        int k = int.Parse(Console.ReadLine()!); // [1, 1'000]

        const int InvalidCost = -1;

        StringBuilder sb = new();
        for (int i = 0; i < k; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int t = tokens[0];
            int sLine = tokens[1];
            int sStation = tokens[2];
            int eLine = tokens[3];
            int eStation = tokens[4];

            int[][] minCost = new int[lineCount + 1][];
            for (int line = 1; line <= lineCount; ++line)
            {
                int stationCount = stationCounts[line];

                minCost[line] = new int[stationCount + 1];
                for (int station = 1; station <= stationCount; ++station)
                {
                    minCost[line][station] = InvalidCost;
                }
            }
            PriorityQueue<(int line, int station, int cost), int> pq = new();

            minCost[sLine][sStation] = 0;
            pq.Enqueue((sLine, sStation, 0), 0);

            while (pq.Count > 0)
            {
                var element = pq.Dequeue();
                int line = element.line;
                int station = element.station;
                int cost = element.cost;

                if (cost > minCost[line][station])
                    continue;

                var adjs = adjList[line][station];
                for (var lln = adjs.First; lln != null; lln = lln.Next)
                {
                    int adjLine = lln.Value.line;
                    int adjStation = lln.Value.station;
                    int adjCost = (line != adjLine) ? t : 1;
                    
                    int oldAdjMinCost = minCost[adjLine][adjStation];
                    int newAdjMinCost = cost + adjCost;
                    if (oldAdjMinCost == InvalidCost || newAdjMinCost < oldAdjMinCost)
                    {
                        minCost[adjLine][adjStation] = newAdjMinCost;
                        pq.Enqueue((adjLine, adjStation, newAdjMinCost), newAdjMinCost);
                    }
                }
            }

            sb.AppendLine($"{minCost[eLine][eStation]}");
        }
        Console.Write(sb);
    }
}