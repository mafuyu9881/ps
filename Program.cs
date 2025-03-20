internal class Program
{
    private static void Main(string[] args)
    {
        // length = 3
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [6, 50]
        int width = tokens[1]; // [6, 50]
        int t = tokens[2]; // [1, 1'000]

        int[,] buffer0 = new int[height, width];
        int[,] buffer1 = new int[height, width];

        int[,] mainBuffer = buffer0;
        int[,] backBuffer = buffer1;

        for (int row = 0; row < height; ++row)
        {
            // length = width = [6, 50]
            // element = [-1, 1'000]
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                
            }
        }
    }
}