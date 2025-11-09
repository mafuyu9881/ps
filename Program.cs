using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            sb.AppendLine((tokens[0] == tokens[1]) ? "OK" : "ERROR");
        }
        Console.Write(sb);
    }
}