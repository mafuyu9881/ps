using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int Height = 8;
        const int Width = 8;

        int count = 0;
        for (int row = 0; row < Height; ++row)
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < Width; ++col)
            {
                if (line[col] == '.')
                    continue;
                
                if (row % 2 != col % 2)
                    continue;
                
                ++count;
            }
        }

        Console.Write(count);
    }
}