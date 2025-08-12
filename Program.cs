class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);
        Console.Write((a + b + c > 21) ? 0 : 1);
    }
}