internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidDepth = -1;
        const int InvalidVertex = -1;

        // length = 2
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 100'000]
        int k = tokens[1]; // [0, n - 1] = [0, 99'999]

        LinkedList<int>[] adjList = new LinkedList<int>[n];
        for (int i = 0; i < adjList.Length; ++i) // max tc = 100'000
        {
            adjList[i] = new();
        }

        for (int i = 0; i < n - 1; ++i) // max tc = 99'999
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            int p = tokens[0];
            int c = tokens[1];

            adjList[p].AddLast(c);
        }

        int[] value = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] depth = new int[n];
        for (int i = 0; i < depth.Length; ++i)
        {
            depth[i] = InvalidDepth;
        }

        Queue<(int v, int depth)> frontier = new();

        int r = 0;
        depth[r] = 0;
        frontier.Enqueue((r, 0));

        int kv = InvalidVertex;

        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();

            int p = element.v;

            if (value[p] == k)
            {
                kv = p;
                break;
            }

            int pDepth = element.depth;
            int cDepth = pDepth + 1;

            var adjs = adjList[p];
            for (var lln = adjs.First; lln != null; lln = lln.Next) // max tc = 2
            {
                var c = lln.Value;
                depth[c] = cDepth;
                frontier.Enqueue((lln.Value, cDepth));
            }
        }

        Console.Write(depth[kv]);
    }
}