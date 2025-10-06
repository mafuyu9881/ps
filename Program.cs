using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine()!;
            for (int j = 0; j < m; ++j)
            {
                sb.Append(s[m - 1 - j]);
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}