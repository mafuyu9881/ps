using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]
        StringBuilder sb = new();
        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            sb.AppendLine(" @@@   @@@ ");
            sb.AppendLine("@   @ @   @");
            sb.AppendLine("@    @    @");
            sb.AppendLine("@         @");
            sb.AppendLine(" @       @ ");
            sb.AppendLine("  @     @  ");
            sb.AppendLine("   @   @   ");
            sb.AppendLine("    @ @    ");
            sb.AppendLine("     @     ");
        }
        Console.Write(sb);
    }
}