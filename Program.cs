using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            int number = int.Parse(Console.ReadLine()!);
            sb.AppendLine($"{number} {number}");
        }
        Console.Write(sb);
    }
}