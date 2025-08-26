class Program
{
    static void Main(string[] args)
    {
        int sab = int.Parse(Console.ReadLine()!);
        int fab = int.Parse(Console.ReadLine()!);
        string output = "high speed rail";
        if (fab < sab)
        {
            output = "flight";
        }
        Console.Write(output);
    }
}