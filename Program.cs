using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] tokens = Console.ReadLine()!.Split();

        StringBuilder sb = new();
        {
            for (int i = 0; i < tokens.Length; ++i)
            {
                sb.Append($"{tokens[i]}DORO ");
            }
        }
        Console.Write(sb);
    }
}