class Program
{
    static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine()!);
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);
        int d = int.Parse(Console.ReadLine()!);
        int p = a / c + ((a % c > 0) ? 1 : 0);
        int q = b / d + ((b % d > 0) ? 1 : 0);
        Console.Write(l - ((p > q) ? p : q));
    }
}