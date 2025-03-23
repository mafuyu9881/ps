internal class Program
{
    private static void Main(string[] args)
    {
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

        Queue<(int v, int depth)> frontier = new();

        frontier.Enqueue((0, 0));

        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();

            int p = element.v;
            int pDepth = element.depth;
            int cDepth = pDepth + 1;

            var adjs = adjList[p];
            for (var lln = adjs.First; lln != null; lln = lln.Next) // max tc = 2
            {
                int c = lln.Value;
                if (value[c] == k)
                {
                    Console.Write(cDepth);
                    return;
                }
                else
                {
                    frontier.Enqueue((c, cDepth));
                }
            }
        }
    }
}