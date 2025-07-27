class Program
{
    static void Main(string[] args)
    {
        // length = 2
        // element = [1, 10'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int t1 = tokens[0];
        int t2 = tokens[1];
        Console.Write(Math.Min(t1, t2));
    }
}