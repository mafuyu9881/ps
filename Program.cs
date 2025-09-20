class Program
{
    static void Main(string[] args)
    {
        int spent = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < 9; ++i)
        {
            spent -= int.Parse(Console.ReadLine()!);
        }
        Console.Write(spent);
    }
}