class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int output = 1;
        for (int i = 0; i < n; ++i)
        {
            output *= 2;
        }
        Console.Write(output);
    }
}