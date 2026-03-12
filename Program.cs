public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!);

        string output;
        if (n * n > 100000000)
        {
            output = "Time limit exceeded";
        }
        else
        {
            output = "Accepted";
        }

        Console.Write(output);
    }
}