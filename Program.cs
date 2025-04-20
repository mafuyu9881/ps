internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int k = tokens[1]; // [1, 2'000'000]

        int[] map = new int[1000001];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int g = tokens[0]; // [1, 10'000]
            int x = tokens[1]; // [1, 1'000'000]
            map[x] = g;
        }

        int maxIces = 0;
        {
            int e = Math.Min(2 * k, map.Length - 1);

            int ices = 0;
            for (int i = 0; i <= e; ++i)
            {
                ices += map[i];
            }
            maxIces = ices;

            for (int i = 1; e + i < map.Length; ++i)
            {
                ices -= map[i - 1];
                ices += map[e + i];
                maxIces = Math.Max(maxIces, ices);
            }
        }
        Console.Write(maxIces);
    }
}