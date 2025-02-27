internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50]

        int donated = 0;

        bool[] visited = new bool[n];
        int remains = n;

        PriorityQueue<(int s, int e, int cost), int> cables = new();

        for (int s = 0; s < n; ++s) // max tc = 50
        {
            string stringToken = Console.ReadLine()!;
            for (int e = 0; e < n; ++e) // max tc = 50
            {
                char charToken = stringToken[e];

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

                cables.Enqueue((s, e, cost), cost);
            }
        }

        while (cables.Count > 0) // max tc = 2'500
        {
            var cable = cables.Dequeue();
            int s = cable.s;
            int e = cable.e;
            int cost = cable.cost;

            if ((s == e) ||
                (visited[s] && visited[e]) ||
                (cost < 1))
                continue;

            if (visited[s] == false)
            {
                visited[s] = true;
                --remains;
            }
            
            if (visited[e] == false)
            {
                visited[e] = true;
                --remains;
            }

            donated -= cost;
        }

        if (remains > 0)
            donated = -1;

        Console.Write(donated);
    }
}