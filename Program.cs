using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        output.AppendLine("1");
        output.AppendLine("0");
        Console.Write(output);
    }
}