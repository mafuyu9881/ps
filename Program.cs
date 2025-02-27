internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50]

        LinkedList<(int v, int cost)>[] cables = new LinkedList<(int, int)>[n];

        int donated = 0;
        
        for (int v0 = 0; v0 < n; ++v0) // max tc = 50
        {
            cables[v0] = new();

            string stringToken = Console.ReadLine()!;
            for (int v1 = 0; v1 < n; ++v1) // max tc = 50
            {
                char charToken = stringToken[v1];

                int cost = 0;
                if (charToken >= 'a' && charToken <= 'z')
                {
                    cost = charToken - 'a' + 1;
                }
                else if (charToken >= 'A' && charToken <= 'Z')
                {
                    cost = charToken - 'A' + 27;
                }

                donated += cost;

                cables[v0].AddLast((v1, cost));
            }
        }

        bool[] visited = new bool[n];

        PriorityQueue<(int v, int cost), int> frontier = new();

        int s = 0;

        visited[s] = true;
        for (var lln = cables[s].First; lln != null; lln = lln.Next)
        {
            frontier.Enqueue(lln.Value, lln.Value.cost);
        }

        while (frontier.Count > 0)
        {
            var vcost = frontier.Dequeue();
            int v = vcost.v;
            int cost = vcost.cost;

            if (visited[v] || cost < 1)
                continue;
            
            visited[v] = true;

            donated -= cost;

            for (var lln = cables[v].First; lln != null; lln = lln.Next)
            {
                frontier.Enqueue(lln.Value, lln.Value.cost);
            }
        }

        Console.Write(donated);
    }
}