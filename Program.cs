internal class Program
{
    private static void Main(string[] args)
    {
        int[] emptyContainerCounts = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Console.Write(emptyContainerCounts.Sum() * 5);
    }
}