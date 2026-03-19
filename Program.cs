using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine()!;

            if (s[s.Length - 1] != '.')
            {
                sb.AppendLine($"{s}.");
            }
            else
            {
                sb.AppendLine(s);
            }
        }

        Console.Write(sb);
    }
}