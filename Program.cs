using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int caseNumber = 0;
        StringBuilder output = new();
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            if (tokens.Length == 1 && tokens[0] == 0)
                break;

            ++caseNumber;

            output.AppendLine($"Case {caseNumber}: Sorting... done!");
        }
        Console.Write(output);
    }
}