class Program
{
    static void Main(string[] args)
    {
        int h = int.Parse(Console.ReadLine()!); // [0, 23]
        int m = int.Parse(Console.ReadLine()!); // [0, 59]
        Console.Write(60 * h + m);
    }
}