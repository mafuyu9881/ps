using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new(Console.ReadLine()!);
        sb.Append('\0');

        int output = 0;
        for (int i = 0; i < sb.Length - 1; ++i)
        {
            if (sb[i] != sb[i + 1])
            {
                ++output;
            }
        }

        Console.WriteLine(output / 2);
    }
}