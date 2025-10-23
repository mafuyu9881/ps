using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int antenna = int.Parse(Console.ReadLine()!);
        int eyes = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        if (antenna >= 3 && eyes <= 4)
        {
            sb.AppendLine("TroyMartian");
        }
        if (antenna <= 6 && eyes >= 2)
        {
            sb.AppendLine("VladSaturnian");
        }
        if (antenna <= 2 && eyes <= 3)
        {
            sb.AppendLine("GraemeMercurian");
        }
        Console.Write(sb);
    }
}