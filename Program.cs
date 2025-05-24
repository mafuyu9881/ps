using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            // length = 2
            // element = [0, 5]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int m = tokens[0];
            int f = tokens[1];
            if (m == 0 && f == 0)
                break;

            sb.AppendLine($"{m + f}");
        }
        Console.Write(sb);
    }
}