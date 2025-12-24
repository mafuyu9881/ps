class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x = tokens[0];
        int y = tokens[1];
        Console.Write((x > y) ? (x + y) : (y - x));
    }
}