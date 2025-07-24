class Program
{
    static void Main(string[] args)
    {
        int elapsed = 0;
        for (int i = 0; i < 4; ++i)
        {
            elapsed += int.Parse(Console.ReadLine()!);
        }
        Console.Write((elapsed > 1500) ? "No" : "Yes");
    }
}