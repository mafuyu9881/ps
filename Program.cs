using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();

        for (int i = 1; i <= n; ++i)
        {
            sb.Append($"{i} ");

            if ((i % 6 == 0) ||
                (i == n))
            {
                sb.Append("Go! ");
            }
        }
        
        Console.Write(sb);
    }
}