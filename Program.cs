using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string tokens = Console.ReadLine()!;

        StringBuilder sb = new();
        sb.AppendLine(":fan::fan::fan:");
        sb.AppendLine($":fan::{tokens}::fan:");
        sb.AppendLine(":fan::fan::fan:");
        Console.Write(sb);
    }
}