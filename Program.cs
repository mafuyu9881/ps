using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new();

        while (true)
        {
            string input = Console.ReadLine()!;
            if (input == "end")
                break;
            
            if (input == "animal")
            {
                output.AppendLine("Panthera tigris");
            }
            else if (input == "tree")
            {
                output.AppendLine("Pinus densiflora");
            }
            else
            {
                output.AppendLine("Forsythia koreana");
            }
        }

        Console.Write(output);
    }
}