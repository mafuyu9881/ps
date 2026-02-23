class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine()!);

        int count = 0;

        while (x > 0)
        {
            count += x & 1;
            x >>= 1;
        }

        Console.Write(count);
    }
}