class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int freeSockets = 0;
        for (int i = 0; i < n; ++i)
        {
            freeSockets += int.Parse(Console.ReadLine()!) - 1;
        }
        ++freeSockets;
        
        Console.Write(freeSockets);
    }
}