using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int t = tokens[0];
        int s = tokens[1];

        StringBuilder output = new();
        if (s == 1 || t < 12 || t > 16) output.Append("280");
        else output.Append("320");
        Console.Write(output);
    }
}