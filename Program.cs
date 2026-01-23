using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int height = 2 * n - 1;
        
        StringBuilder output = new();
        for (int i = 0; i < height; ++i)
        {
            if (i < height / 2)
            {
                output.Append('*', i + 1);
                output.Append(' ', n - (i + 1));
                output.Append(' ', n - (i + 1));
                output.Append('*', i + 1);
            }
            else
            {
                output.Append('*', n - ((i + 1) - n));
                output.Append(' ', (i + 1) - n);
                output.Append(' ', (i + 1) - n);
                output.Append('*', n - ((i + 1) - n));
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}