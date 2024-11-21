internal class Program
{
    private static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine()!);
        int y = int.Parse(Console.ReadLine()!);

        int output;
        if (x > 0 && y > 0) output = 1;
        else if (x < 0 && y > 0) output = 2;
        else if (x < 0 && y < 0) output = 3;
        else output = 4;
        
        Console.Write(output);
    }
}