class Program
{
    static void Main(string[] args)
    {
        int[] tokens0 = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] tokens1 = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.Write(Math.Min(tokens0[0] + tokens1[1], tokens0[1] + tokens1[0]));
    }
}