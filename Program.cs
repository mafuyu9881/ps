class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < n; ++i)
        {
            string name = Console.ReadLine()!;
            if (name.Contains('S'))
            {
                Console.Write(name);
                break;
            }
        }
    }
}