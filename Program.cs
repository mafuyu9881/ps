using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        LinkedList<int>[] adjList = new LinkedList<int>[n];
        for (int srcV = 0; srcV < n; ++srcV)
        {
            LinkedList<int> srcAdjs = new();
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int dstV = 0; dstV < n; ++dstV)
            {
                if (tokens[dstV] == 0)
                    continue;

                srcAdjs.AddLast(dstV);
            }
            adjList[srcV] = srcAdjs;
        }

        StringBuilder output = new();
        for (int srcV = 0; srcV < n; ++srcV) // max tc = 100
        {
            int[] reachable = new int[n];
            Queue<int> visitingQueue = new();

            reachable[srcV] = 0;
            visitingQueue.Enqueue(srcV);
            while (visitingQueue.Count > 0)
            {
                int v = visitingQueue.Dequeue();

                var adjs = adjList[v];
                for (var node = adjs.First; node != null; node = node.Next)
                {
                    int adjV = node.Value;
                    if (reachable[adjV] == 1)
                        continue;

                    reachable[adjV] = 1;
                    visitingQueue.Enqueue(adjV);
                }
            }

            for (int i = 0; i < reachable.Length; ++i)
            {
                output.Append($"{reachable[i]} ");
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}