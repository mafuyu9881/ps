internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [5, 100]
        int width = tokens[1]; // [5, 100]

        char[,] map = new char[height, width];
        (int row, int col) lt = (height - 1, width - 1);
        (int row, int col) rb = (0, 0);
        for (int row = 0; row < height; ++row) // max tc = 100
        {
            string s = Console.ReadLine()!;
            for (int col = 0; col < width; ++col) // max tc = 100
            {
                map[row, col] = s[col];

                if (map[row, col] == '#')
                {
                    if (row < lt.row)
                    {
                        lt.row = row;
                    }

                    if (row > rb.row)
                    {
                        rb.row = row;
                    }

                    if (col < lt.col)
                    {
                        lt.col = col;
                    }

                    if (col > rb.col)
                    {
                        rb.col = col;
                    }
                }
            }
        }

        string[] sides = new string[] { "UP", "RIGHT", "DOWN", "LEFT" };
        (int row, int col)[] vertices = new (int, int)[]
        {
            lt,
            (lt.row, rb.col),
            rb,
            (rb.row, lt.col)
        };
        int currIndex = 3;
        int nextIndex = 0;
        while (nextIndex < 4)
        {
            var currVertex = vertices[currIndex];
            var nextVertex = vertices[nextIndex];

            int row = (currVertex.row + nextVertex.row) / 2;
            int col = (currVertex.col + nextVertex.col) / 2;

            if (map[row, col] == '.')
            {
                Console.Write(sides[currIndex]);
                break;
            }

            currIndex = nextIndex++;
        }
    }
}