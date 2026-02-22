using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int MaxPassedMonths = 45;

        long[] fibonacci = new long[MaxPassedMonths + 1];
        {
            fibonacci[0] = 1;
            fibonacci[1] = 1;
            for (int i = 2; i <= MaxPassedMonths; ++i)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
        }

        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        {
            for (int i = 0; i < t; ++i)
            {
                output.AppendLine($"{fibonacci[int.Parse(Console.ReadLine()!)]}");
            }
        }

        Console.Write(output);
    }
}