using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        // length = 2
        // element = [1, 100]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[,] matrix = new int[height, width];
        for (int i = 0; i < 2; ++i) // tc = 2
        {
            for (int row = 0; row < height; ++row) // max tc = 100
            {
                // length = col = [1, 100]
                // element = [-100, 100]
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                for (int col = 0; col < width; ++col) // max tc = 100
                {
                    matrix[row, col] += tokens[col];
                }
            }
        }

        StringBuilder sb = new();
        for (int row = 0; row < height; ++row) // max tc = 100
        {
            for (int col = 0; col < width; ++col) // max tc = 100
            {
                sb.Append($"{matrix[row, col]} ");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}