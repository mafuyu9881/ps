internal class Program
{
    private static void Main(string[] args)
    {
        const int Offsets = 4;
        int[] XOffsets = new int[Offsets] { 0, 1, 0, -1 };
        int[] YOffsets = new int[Offsets] { 1, 0, -1, 0 };

        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = integerTokens[0]; // [0, 100'000]
        int t = integerTokens[1]; // [1, 1'000'000'000]

        (int x, int y) coord = (0, 0);
        int elapsed = 0;
        int direction = 1;
        for (int i = 0; i < n; ++i)
        {
            string[] stringTokens = Console.ReadLine()!.Split();
            int ti = int.Parse(stringTokens[0]); // [0, 1'000'000'000]
            string rotation = stringTokens[1];

            int interval = ti - elapsed;
            coord.x += XOffsets[direction] * interval;
            coord.y += YOffsets[direction] * interval;
            elapsed = ti;

            if (rotation == "left")
            {
                direction = (Offsets + direction - 1) % Offsets;
            }
            else // if (rotation == "right")
            {
                direction = (direction + 1) % Offsets;
            }
        }

        {
            int interval = t - elapsed;
            coord.x += XOffsets[direction] * interval;
            coord.y += YOffsets[direction] * interval;
            elapsed = t;
        }

        Console.Write($"{coord.x} {coord.y}");
    }
}