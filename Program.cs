using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n == 0)
                break;

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    sb.Append('*');
                }
                sb.AppendLine();
            }
        }
        Console.Write(sb);
    }
}