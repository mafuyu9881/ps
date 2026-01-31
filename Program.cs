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
            int stars = (row < height / 2) ? (row + 1) : (width - (row + 1 - width));
            for (int col = 0; col < stars; ++col)
            {
                output.Append('*');
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}