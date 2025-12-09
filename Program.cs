class Program
{
    static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine()!);
        int m = int.Parse(Console.ReadLine()!);
        int l = int.Parse(Console.ReadLine()!);

        Console.Write(((1 * s + 2 * m + 3 * l) < 10) ? "sad" : "happy");
    }
}