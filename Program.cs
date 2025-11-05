using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            int x = int.Parse(Console.ReadLine()!);

            if (x % 2 == 0)
            {
                sb.AppendLine($"{x} is even");
            }
            else
            {
                sb.AppendLine($"{x} is odd");
            }
        }
        Console.Write(sb);
    }
}