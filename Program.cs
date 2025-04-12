using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [?, ?]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = ?
        {
            int n = int.Parse(Console.ReadLine()!); // [2, 1'000]

            // length = [2, 1'000]
            // element = [1, 1'000]
            // max tc = 1'000
            int[] permutation = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int[] adjList = new int[n + 1];
            for (int j = 1; j < adjList.Length; ++j) // max tc = 1'000
            {
                adjList[j] = permutation[j - 1];
            }

            int cycles = 0;
            bool[] visited = new bool[adjList.Length];
            for (int s = 1; s < adjList.Length; ++s) // max tc = 1'000
            {
                if (visited[s])
                    continue;

                Stack<int> frontier = new();

                visited[s] = true;
                frontier.Push(s);
                while (frontier.Count > 0) // global max tc = 1'000
                {
                    int v = frontier.Pop();

                    int adjV = adjList[v];
                    if (adjV == v || visited[adjV])
                    {
                        ++cycles;
                    }
                    else
                    {
                        visited[adjV] = true;
                        frontier.Push(adjV);
                    }
                }
            }
            sb.AppendLine($"{cycles}");
        }
        Console.Write(sb);
    }
}