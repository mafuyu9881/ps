using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] requirements = new int[] { 1, 1, 2, 2, 2, 8 };
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        StringBuilder output = new();
        for (int i = 0; i < requirements.Length; ++i)
        {
            output.Append($"{requirements[i] - tokens[i]} ");
        }
        Console.Write(output);
    }
}