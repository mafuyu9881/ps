internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        SortedDictionary<int, int> xs = new();
        SortedDictionary<int, int> ys = new();

        LinkedList<(int x, int y)> points = new();
        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            // length = 2
            // element = [-2^31 + 1, 2^31 - 1]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0];
            int y = tokens[1];
            
            CollectPoint(xs, x);
            CollectPoint(ys, y);

            points.AddLast((x, y));
        }

        int lines = 0;
        for (var lln = points.First; lln != null; lln = lln.Next) // max tc = 100'000
        {
            lines += ComputeLines(xs, lln.Value.x);
            lines += ComputeLines(ys, lln.Value.y);
        }
        Console.Write(lines);
    }

    private static void CollectPoint(SortedDictionary<int, int> ps, int p)
    {
        if (ps.ContainsKey(p)) // max tc = log2(100'000) = 16.xxx
        {
            ++ps[p]; // max tc = 16.xxx
        }
        else
        {
            ps.Add(p, 1); // max tc = 16.xxx
        }
    }

    private static int ComputeLines(SortedDictionary<int, int> ps, int p)
    {
        int lines = 0;

        if (ps.ContainsKey(p) == false)
            return lines;

        lines = ps[p] - 1;
        
        --ps[p];
        if (ps[p] < 1)
            ps.Remove(p);

        return lines;
    }
}