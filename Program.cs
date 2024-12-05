internal class Program
{
    private static void Main(string[] args)
    {
        long s = long.Parse(Console.ReadLine()!);
        uint output = 1;
        while (s >= 0)
        {
            s -= output++;
        }
        Console.Write(output - 2);
    }
}