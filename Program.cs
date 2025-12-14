class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int a = tokens[1];

        Console.Write(Math.Min(s / 2, a / 2));
    }
}