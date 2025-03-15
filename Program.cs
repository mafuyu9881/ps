using System.Text;

internal class Program
{
    private struct Route
    {
        public int S; // [0, 1'000'000'000]
        public int E; // [0, 1'000'000'000]
        public int C; // [1, 1'000'000'000]

        public Route(int s, int e, int c)
        {
            S = s;
            E = e;
            C = c;
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        Route[] routeArr = new Route[n];
        for (int i = 0; i < n; ++i) // max tc = 200'000
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            routeArr[i] = new(tokens[0], tokens[1], tokens[2]);
        }
        Array.Sort(routeArr, (x, y) => x.S.CompareTo(y.S));

        LinkedList<Route> routeLL = new();
        for (int i = 0; i < n; ++i) // max tc = 200'000
        {
            routeLL.AddLast(routeArr[i]);
        }

        var currLLN = routeLL.First;
        while (true)
        {
            if (currLLN == null)
                break;

            var nextLLN = currLLN.Next;
            
            if (nextLLN != null && currLLN.Value.E >= nextLLN.Value.S)
            {
                currLLN.ValueRef.E = Math.Max(currLLN.Value.E, nextLLN.Value.E);
                currLLN.ValueRef.C = Math.Min(currLLN.Value.C, nextLLN.Value.C);
                routeLL.Remove(nextLLN);
                nextLLN = currLLN;
            }

            currLLN = nextLLN;
        }

        StringBuilder sb = new();
        sb.AppendLine($"{routeLL.Count}");
        for (var lln = routeLL.First; lln != null; lln = lln.Next)
        {
            sb.AppendLine($"{lln.Value.S} {lln.Value.E} {lln.Value.C}");
        }
        Console.Write(sb);
    }
}