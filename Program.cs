using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine()!);
        int width = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < height; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                sb.Append("*");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}