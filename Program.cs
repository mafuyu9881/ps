class Program
{
    static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        Console.Write(tokens[0] == tokens[1] ? 1 : 0);
    }
}