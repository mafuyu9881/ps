class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        string output = "0";
        if (a > b) output = "1";
        else if (a < b) output = "-1";
        Console.Write(output);
    }
}