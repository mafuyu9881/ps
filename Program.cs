class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int k = tokens[0];
        int n = tokens[1];
        int m = tokens[2];
        Console.Write(Math.Max(0, k * n - m));
    }
}