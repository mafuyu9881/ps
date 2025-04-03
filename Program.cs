using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 1'000]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 1'000
        {
            // length = 4
            // element = [1, 1'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int side = tokens[0];
            int x = tokens[2];
            int y = tokens[3];

            int placeable = 0;
            bool[,] chocolate = new bool[side, side];
            for (int currRow = 0; currRow < side; ++currRow) // max tc = 1'000
            {
                for (int currCol = 0; currCol < side; ++currCol) // max tc = 1'000
                {
                    int prevRow = currRow - y;
                    int prevCol = currCol - x;
                    if (prevRow >= 0 && prevCol >= 0 && chocolate[prevRow, prevCol])
                        continue;

                    chocolate[currRow, currCol] = true;
                    ++placeable;
                }
            }
            sb.AppendLine($"{placeable}");
        }
        Console.Write(sb);
    }
}