using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 1; i <= n; ++i)
        {
            sb.AppendLine($"Hello World, Judge {i}!");
        }
        Console.Write(sb);
    }
}