using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            string semina = Console.ReadLine()!;
            if (semina == "Algorithm")
            {
                sb.AppendLine("204");
            }
            else if (semina == "DataAnalysis")
            {
                sb.AppendLine("207");
            }
            else if (semina == "ArtificialIntelligence")
            {
                sb.AppendLine("302");
            }
            else if (semina == "CyberSecurity")
            {
                sb.AppendLine("B101");
            }
            else if (semina == "Network")
            {
                sb.AppendLine("303");
            }
            else if (semina == "Startup")
            {
                sb.AppendLine("501");
            }
            else if (semina == "TestStrategy")
            {
                sb.AppendLine("105");
            }
        }
        Console.Write(sb);
    }
}