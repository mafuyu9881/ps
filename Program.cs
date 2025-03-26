internal class Program
{
    private static void Main(string[] args)
    {
        // length = 3
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 80]
        int k = tokens[1]; // [1, n] = [1, 80]
        int x = tokens[2]; // [1, 200]

        (int a, int b)[] stats = new (int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 80
        {
            // length = 2
            // element = [0, x] = [0, 200]
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            stats[i] = (a, b);
        }

        bool[] visited = new bool[64000000 + 1];
    }
}