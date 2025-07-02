class Program
{
    static void Main(string[] args)
    {
        int count = 0;
        while (true)
        {
            string line = Console.ReadLine()!;
            if (string.IsNullOrEmpty(line))
                break;

            ++count;
        }
        Console.Write(count);
    }
}