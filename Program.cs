class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);
        int d = int.Parse(Console.ReadLine()!);

        string output;
        if ((a == 8 || a == 9) &&
            (d == 8 || d == 9) &&
            (b == c))
        {
            output = "ignore";
        }
        else
        {
            output = "answer";
        }
        Console.Write(output);
    }
}