internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        n -= 1;

        int strides = 1;

        for (int i = 1; n > 0; ++i)
        {
            ++strides;
            n -= 6 * i;
        }

        Console.Write(strides);
    }
}