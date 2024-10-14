internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Console.Write(tokens[0] * tokens[1] - tokens[2] * tokens[3] * tokens[4]);
    }
}