internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int output = 0;
        for (int i = 0; i < n; ++i)
        {
            output += int.Parse(Console.ReadLine()!);
        }

        Console.Write(output);
    }
}