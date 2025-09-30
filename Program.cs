class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.Write((char)(0xAC00 + (n - 1)));
    }
}