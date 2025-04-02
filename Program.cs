internal class Program
{
    const int InvalidHouse = -1;
    const int Infinity = -1;

    private static int _s = InvalidHouse;
    private static int _e = InvalidHouse;

    private static LinkedList<(int v, int weightLimit)>[] _adjList = null!;

    private static int _maxCapacity = 0;

    private static bool[] _visited = null!;

    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
        int n = tokens[0]; // [2, 100'000]
        int m = tokens[1]; // [1, 300'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
        _s = tokens[0]; // [1, n] = [1, 100'000]
        _e = tokens[1]; // [1, n] = [1, 100'000]

        _adjList = new LinkedList<(int, int)>[n + 1];
        for (int i = 0; i < _adjList.Length; ++i) // max tc = n = 100'000
        {
            _adjList[i] = new();
        }

        for (int i = 0; i < m; ++i) // max tc = m = 300'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 2
            int h1 = tokens[0]; // [1, n] = [1, 100'000]
            int h2 = tokens[1]; // [1, n] = [1, 100'000]
            int k = tokens[2]; // [1, 1'000'000]
            _adjList[h1].AddLast((h2, k));
            _adjList[h2].AddLast((h1, k));
        }
        
        _visited = new bool[_adjList.Length];
        _visited[_s] = true;
        DFS(_s, Infinity);
        _visited[_s] = false;

        Console.Write(_maxCapacity);
    }

    private static void DFS(int v, int weightLimit)
    {
        var adjs = _adjList[v];
        for (var lln = adjs.First; lln != null; lln = lln.Next)
        {
            int adjV = lln.Value.v;
            if (_visited[adjV])
                continue;

            int adjWeightLimit;
            if (weightLimit == Infinity)
            {
                adjWeightLimit = lln.Value.weightLimit;
            }
            else
            {
                adjWeightLimit = Math.Min(weightLimit, lln.Value.weightLimit);
            }
            
            if (adjV == _e)
            {
                _maxCapacity = Math.Max(_maxCapacity, adjWeightLimit);
            }
            else
            {
                _visited[adjV] = true;
                DFS(adjV, adjWeightLimit);
                _visited[adjV] = false;
            }
        }
    }
}