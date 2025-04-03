internal class Program
{
    const int InvalidTravelTime = -1;

    private static LinkedList<(int dst, int travelTime)>[] _adjList = null!;
    
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3
        int n = tokens[0]; // [1, 1'000]
        int m = tokens[1]; // [1, 10'000]
        int x = tokens[2]; // [1, n] = [1, 1'000]

        _adjList = new LinkedList<(int, int)>[n + 1];
        for (int i = 1; i < _adjList.Length; ++i) // max tc = 1'000
        {
            _adjList[i] = new();
        }

        for (int i = 0; i < m; ++i) // max tc = 10'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3
            int src = tokens[0]; // [1, 1'000]
            int dst = tokens[1]; // [1, 1'000]
            int travelTime = tokens[2]; // [1, 100]
            _adjList[src].AddLast((dst, travelTime));
        }

        int[] xMinTravelTimes = ComputeMinTravelTimes(x);

        int maxRoundTripTime = InvalidTravelTime;
        for (int s = 1; s <= n; ++s) // max tc = 1'000
        {
            if (s == x)
                continue;

            int[] sMinTravelTimes = ComputeMinTravelTimes(s);

            int newMaxRoundTripTime = sMinTravelTimes[x] + xMinTravelTimes[s];

            if (maxRoundTripTime != InvalidTravelTime && maxRoundTripTime >= newMaxRoundTripTime)
                continue;

            maxRoundTripTime = newMaxRoundTripTime;
        }
        Console.Write(maxRoundTripTime);
    }

    private static int[] ComputeMinTravelTimes(int s)
    {
        int[] minTravelTimes = new int[_adjList.Length];
        for (int i = 1; i < minTravelTimes.Length; ++i) // max tc = 1'000
        {
            minTravelTimes[i] = InvalidTravelTime;
        }

        PriorityQueue<(int v, int travelTime), int> pq = new();

        minTravelTimes[s] = 0;
        pq.Enqueue((s, minTravelTimes[s]), minTravelTimes[s]);

        while (pq.Count > 0)
        {
            var element = pq.Dequeue();
            int v = element.v;
            int travelTime = element.travelTime;

            if (minTravelTimes[v] < travelTime)
                continue;

            var adjs = _adjList[v];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adjV = lln.Value.dst;

                int oldMinTravelTime = minTravelTimes[adjV];
                int newMinTravelTime = travelTime + lln.Value.travelTime;
                if (oldMinTravelTime != InvalidTravelTime && oldMinTravelTime <= newMinTravelTime)
                    continue;

                minTravelTimes[adjV] = newMinTravelTime;
                pq.Enqueue((adjV, newMinTravelTime), newMinTravelTime);
            }
        }

        return minTravelTimes;
    }
}