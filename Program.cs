class Program
{
    static void Main(string[] args)
    {
        const char Guard = 'X';

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        bool[] rowFilled = new bool[height];
        bool[] colFilled = new bool[width];

        for (int row = 0; row < height; ++row)
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                char c = line[col];
                if (c == Guard)
                {
                    rowFilled[row] = true;
                    colFilled[col] = true;
                }
            }
        }

        int rowBlanks = 0;
        for (int i = 0; i < rowFilled.Length; ++i)
        {
            if (rowFilled[i] == false)
            {
                ++rowBlanks;
            }
        }

        int colBlanks = 0;
        for (int i = 0; i < colFilled.Length; ++i)
        {
            if (colFilled[i] == false)
            {
                ++colBlanks;
            }
        }

        Console.Write(Math.Max(rowBlanks, colBlanks));
    }
}