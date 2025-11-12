class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        int a = input[0] - '0';
        int b = input[4] - '0';
        int c = input[8] - '0';

        Console.Write((a + b == c) ? "YES" : "NO");
    }
}