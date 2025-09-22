class Program
{
    static void Main(string[] args)
    {
        const int Students = 5;
        int sum = 0;
        for (int i = 0; i < Students; ++i)
        {
            sum += Math.Max(40, int.Parse(Console.ReadLine()!));
        }
        Console.Write(sum / Students);
    }
}