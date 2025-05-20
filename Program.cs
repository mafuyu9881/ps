internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        // length = 3
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0]; // [-10'000, 10'000]
        int b = tokens[1]; // [-10'000, 10'000]
        int c = tokens[2]; // [-100'000, 100'000]

        // length = 4
        // element = [-100'000, 100'000]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x1 = tokens[0];
        int x2 = tokens[1];
        int y1 = tokens[2];
        int y2 = tokens[3];

        const int Vertices = 4;
        (int x, int y)[] coords = new (int, int)[Vertices]
        {
            (x1, y1),
            (x1, y2),
            (x2, y1),
            (x2, y2),
        };

        int up = 0;
        int down = 0;
        for (int i = 0; i < Vertices; ++i)
        {
            int x = coords[i].x;
            int y = coords[i].y;

            int j = a * x + b * y + c;

            if (j >= 0)
            {
                ++up;
            }

            if (j <= 0)
            {
                ++down;
            }
        }

        if (up == Vertices || down == Vertices)
        {
            Console.Write("Lucky");
        }
        else
        {
            Console.Write("Poor");
        }
    }
}