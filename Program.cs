using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.Write($"{tokens[1] - tokens[0]} {tokens[1]}");
    }
}