using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        sb.AppendLine($"{n}");
        sb.AppendLine("1");
        Console.Write(sb);
    }
}