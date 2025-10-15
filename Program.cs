using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            double n = double.Parse(Console.ReadLine()!);
            if (n < 0)
                break;

            sb.AppendLine($"Objects weighing {n:F2} on Earth will weigh {n * 0.167:F2} on the moon.");
        }
        Console.Write(sb);
    }
}