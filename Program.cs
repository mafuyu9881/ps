using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[,] map = new int[height, width];
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                map[row, col] = tokens[col];
            }
        }
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int k = tokens[0];

        StringBuilder output = new();
        for (int l = 0; l < k; ++l)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int i = tokens[0] - 1;
            int j = tokens[1] - 1;
            int x = tokens[2] - 1;
            int y = tokens[3] - 1;

            int sum = 0;
            for (int row = i; row <= x; ++row)
            {
                for (int col = j; col <= y; ++col)
                {
                    sum += map[row, col];
                }
            }
            
            output.AppendLine($"{sum}");
        }

        Console.Write(output);
    }
}