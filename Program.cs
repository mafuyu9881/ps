using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int height = 2 * n - 1;
        int width = n;

        StringBuilder output = new();
        for (int row = 0; row < height; ++row)
        {
            int blanks = (row < height / 2) ? (width - 1) - row : row - (width - 1);
            for (int col = 0; col < width; ++col)
            {
                output.Append((col < blanks) ? ' ' : '*');
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}