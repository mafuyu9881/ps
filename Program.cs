using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int brains = tokens[0];
            int requiredBrains = tokens[1];

            if (brains < requiredBrains)
            {
                output.AppendLine("NO BRAINS");
            }
            else
            {
                output.AppendLine("MMM BRAINS");
            }
        }
        Console.Write(output);
    }
}