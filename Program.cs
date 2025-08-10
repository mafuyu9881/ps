class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine()!) % 7;
        Console.Write(x == 2 ? 1 : 0);
    }
}