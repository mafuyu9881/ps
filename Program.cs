class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] fingers = { 2, 1, 2, 3, 4, 5, 4, 3, 2, 1 };

        Console.Write(fingers[n % 8]);
    }
}