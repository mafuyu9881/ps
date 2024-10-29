internal class Program
{
    private static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine()!);

        int output = l / 5;
        
        if (l % 5 != 0) ++output;
        
        Console.Write(output);
    }
}