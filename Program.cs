public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        long output = 1;
        for (int i = 2; i <= n; ++i)
        {
            output *= i;
        }

        Console.Write(output / 604800);
    }
}