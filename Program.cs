using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        {
            for (int i = 0; i < t; ++i)
            {
                int n = int.Parse(Console.ReadLine()!);

                long result = 0;
                {
                    for (int k = 1; k < n + 1; ++k)
                    {
                        result += (long)k * (k + 1) * (k + 2) / 2;
                    }
                }
                output.AppendLine($"{result}");
            }
        }
        Console.Write(output);
    }
}