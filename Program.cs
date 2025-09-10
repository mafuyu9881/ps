class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int l = tokens[0];
        int p = tokens[1];
        int participants = l * p;
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.Write($"{tokens[0] - participants} {tokens[1] - participants} {tokens[2] - participants} {tokens[3] - participants} {tokens[4] - participants}");
    }
}