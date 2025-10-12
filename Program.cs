using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            string? line = Console.ReadLine();
            if (line == null)
                break;

            sb.AppendLine(line);
        }
        Console.Write(sb);
    }
}