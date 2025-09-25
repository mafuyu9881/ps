using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            sb.AppendLine($"{2 - (tokens[0] - tokens[1])}");
        }
        Console.Write(sb);
    }
}