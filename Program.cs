class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];

        Console.Write(Math.Max(Math.Max(a + b, b + c), c + a));
    }
}