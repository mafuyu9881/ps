using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            int k = int.Parse(Console.ReadLine()!);
            for (int j = 0; j < k; ++j)
            {
                sb.Append('=');
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}