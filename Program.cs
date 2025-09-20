class Program
{
    static void Main(string[] args)
    {
        int[] tokens0 = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] tokens1 = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.Write(Math.Max(tokens0.Sum(), tokens1.Sum()));
    }
}