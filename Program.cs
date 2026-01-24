using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int height = 2 * n - 1;
        int width = 2 * n - 1;

        StringBuilder output = new();
        for (int i = 0; i < height; ++i)
        {
            if (i < height / 2)
            {
                output.Append(' ', i);
                output.Append('*', width - i * 2);
            }
            else
            {
                output.Append(' ', width / 2 - (i - width / 2));
                output.Append('*', 2 * (i - width / 2) + 1);
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}