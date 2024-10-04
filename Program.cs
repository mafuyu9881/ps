internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int sum = 0;
        for (int i = 1; i < n + 1; ++i)
        {
            sum += i;
        }
        Console.Write(sum);
    }
}