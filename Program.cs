internal class Program
{
    private static void Main(string[] args)
    {
        long s = long.Parse(Console.ReadLine()!);
        uint output = 0;
        while (s > output)
        {
            s -= ++output;
        }
        Console.Write(output);
    }
}