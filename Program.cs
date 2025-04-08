using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            string? token = Console.ReadLine();
            if (string.IsNullOrEmpty(token))
                break;

            sb.AppendLine(token);
        }
        Console.Write(sb);
    }
}