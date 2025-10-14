using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            double n = double.Parse(Console.ReadLine()!);
            if (n == 0)
                break;

            sb.AppendLine($"{(1 + n + Math.Pow(n, 2) + Math.Pow(n, 3) + Math.Pow(n, 4)):F2}");
        }
        Console.Write(sb);
    }
}