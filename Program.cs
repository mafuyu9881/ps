internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        SortedSet<int> xPoints = new();
        SortedSet<int> yPoints = new();
        
        SortedSet<int> xLines = new();
        SortedSet<int> yLines = new();

        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            // length = 2
            // element = [-2^31 + 1, 2^31 - 1]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0];
            int y = tokens[1];
            
            if (xPoints.Contains(x))
                xLines.Add(x);

            if (yPoints.Contains(y))
                yLines.Add(y);

            xPoints.Add(x);
            yPoints.Add(y);
        }

        Console.Write(xLines.Count + yLines.Count);
    }
}