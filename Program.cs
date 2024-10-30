internal class Program
{
    private static void Main(string[] args)
    {
        DateTime now = DateTime.Now;

        Console.Write($"{now.Year}-{now.Month}-{now.Day}");
    }
}