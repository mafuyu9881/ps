using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            output.AppendLine("I love DGU");
        }
        
        Console.Write(output);
    }
}