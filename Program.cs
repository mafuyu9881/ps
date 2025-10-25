class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        char[] responses = new char[n];
        for (int i = 0; i < n; ++i)
        {
            responses[i] = Console.ReadLine()![0];
        }

        int corrects = 0;
        for (int i = 0; i < n; ++i)
        {
            if (responses[i] == Console.ReadLine()![0])
            {
                ++corrects;
            }
        }
        Console.Write(corrects);
    }
}