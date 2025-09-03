using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n - i; ++j)
            {
                sb.Append("*");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}