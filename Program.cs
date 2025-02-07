internal class Program
{
    private static (int row, int col)[] _zero = new (int, int)[]
    {
        (1, 2), (1, 3), (2, 1), (2, 4), (3, 1), (3, 4), (4, 1), (4, 4), (5, 2), (5, 3)
    };
    
    private static (int row, int col)[] _one = new (int, int)[]
    {
        (1, 3), (2, 2), (2, 3), (3, 3), (4, 3), (5, 3)
    };

    private static (int row, int col)[] _two = new (int, int)[]
    {
    };

    private static (int row, int col)[] _three = new (int, int)[]
    {
    };

    private static (int row, int col)[] _four = new (int, int)[]
    {
    };
    
    private static (int row, int col)[] _five = new (int, int)[]
    {
    };
    
    private static (int row, int col)[] _six = new (int, int)[]
    {
    };

    private static (int row, int col)[] _seven = new (int, int)[]
    {
    };

    private static (int row, int col)[] _eight = new (int, int)[]
    {
    };

    private static (int row, int col)[] _nine = new (int, int)[]
    {
    };

    private static void Main(string[] args)
    {
        int boardHeight = 7;
        int boardWidth;
        
        int[][] map = new int[boardHeight][];
        for (int row = 0; row < map.Length; ++row) // tc = 7
        {
            string s = Console.ReadLine()!;
            map[row] = new int[s.Length];
            boardWidth = s.Length;
            for (int col = 0; col < s.Length; ++col)
            {
                map[row][col] = s[col] - '0';
            }
        }

        
    }
}