internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Console.Write(((tokens[0] * 100) >= tokens[1]) ? "Yes" : "No");
    }
}