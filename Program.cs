internal class Program
{
    private const int Height = 5;
    private const int Width = 5;

    private const int Apple = 1;
    private const int Obstacle = -1;
    
    private const int Offsets = 4;
    private static int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
    private static int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

    const int InvalidMoves = -1;

    private static void Main(string[] args)
    {
        int[] tokens = null!;

        int[] map = new int[Height * Width];
        for (int row = 0; row < Height; ++row)
        {
            // length = Width
            // element = [-1, 1]
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < Width; ++col)
            {
                map[row * Width + col] = tokens[col];
            }
        }

        // length = 2
        // element = [0,4]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int startRow = tokens[0];
        int startCol = tokens[1];
        int startIndex = startRow * Width + startCol;

        int minMoves = InvalidMoves;
        int eatenApples = 0;

        map[startIndex] = Obstacle;

        DFS(map, ref minMoves, ref eatenApples, startRow, startCol, 0);

        Console.Write(minMoves);
    }

    private static void DFS(int[] map, ref int minMoves, ref int eatenApples, int row, int col, int prevMoves)
    {
        int currMoves = prevMoves + 1;

        for (int i = 0; i < Offsets; ++i)
        {
            int adjRow = row + RowOffsets[i];
            if (adjRow < 0 || adjRow > Height - 1)
                continue;
                
            int adjCol = col + ColOffsets[i];
            if (adjCol < 0 || adjCol > Width - 1)
                continue;

            int adjIndex = adjRow * Width + adjCol;
            int originalAttribute = map[adjIndex];
            if (originalAttribute == Obstacle)
                continue;

            if (originalAttribute == Apple)
                ++eatenApples;
            
            if ((eatenApples >= 3) && (minMoves == InvalidMoves || currMoves < minMoves))
                minMoves = currMoves;
            
            map[adjIndex] = Obstacle;

            DFS(map, ref minMoves, ref eatenApples, adjRow, adjCol, currMoves);

            if (originalAttribute == Apple)
                --eatenApples;

            map[adjIndex] = originalAttribute;
        }
    }
}