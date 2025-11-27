class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int w = tokens[1];
        int h = tokens[2];
        int l = tokens[3];
        Console.Write(Math.Min(n, (w / l) * (h / l)));
    }
}