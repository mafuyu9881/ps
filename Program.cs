using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [1, 1'000'000]
            int b = tokens[1]; // [1, 1'000'000]
            if (a == 0 && b == 0)
                break;

            sb.AppendLine((a > b) ? "Yes" : "No");
        }
        Console.Write(sb);
    }
}