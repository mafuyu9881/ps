using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            sb.AppendLine($"{i + 1}. {Console.ReadLine()!}");
        }
        Console.Write(sb);
    }
}