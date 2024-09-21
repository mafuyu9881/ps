using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder input = new(Console.ReadLine()!);
        for (int i = 0; i < input.Length; ++i)
        {
            input[i] -= (char)32;
        }

        Console.WriteLine(input);
    }
}