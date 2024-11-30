internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Console.Write((n % 2 != 0) ? "SK" : "CY");
    }
}