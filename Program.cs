internal class Program
{
    private static void Main(string[] args)
    {
        int cupcakeCount = 0;
        cupcakeCount += int.Parse(Console.ReadLine()!) * 8;
        cupcakeCount += int.Parse(Console.ReadLine()!) * 3;
        Console.Write(cupcakeCount - 28);
    }
}