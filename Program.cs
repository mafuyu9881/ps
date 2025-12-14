class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        while (true)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n == -1)
                break;

            sum += n;
        }
        Console.Write(sum);
    }
}