internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [0, 20]

        long output = 1;
        for (int i = n; i > 0; --i)
        {
            output *= i;
        }
        Console.Write(output);
    }
}