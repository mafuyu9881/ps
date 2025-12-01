class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int h = tokens[1];
        int v = tokens[2];
        Console.Write(Math.Max(n - h, h) * Math.Max(n - v, v) * 4);
    }
}