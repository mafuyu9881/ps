using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int width = 2 * (n - 1) + 1;
        
        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int stars = 2 * i + 1;

            int blanks = (width - stars) / 2;

            output.Append(' ', blanks);
            output.Append('*', stars);
            output.AppendLine();
        }
        Console.Write(output);
    }
}