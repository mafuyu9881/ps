using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine()!);
        int y = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = x; i <= y; i += 60)
        {
            sb.AppendLine($"All positions change in year {i}");
        }
        Console.Write(sb);
    }
}