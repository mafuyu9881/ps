using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int width = 2 * (n - 1) + 1;
        
        StringBuilder output = new();
        for (int i = width; i > 0; --i)
        {
            int stars = 2 * ((i > n) ? width - i : i - 1) + 1;

            int blanks = (width - stars) / 2;

            output.Append(' ', blanks);
            output.Append('*', stars);
            output.AppendLine();
        }
        Console.Write(output);
    }
}