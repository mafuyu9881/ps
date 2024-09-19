using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        output.AppendLine("NFC West       W   L  T");
        output.AppendLine("-----------------------");
        output.AppendLine("Seattle        13  3  0");
        output.AppendLine("San Francisco  12  4  0");
        output.AppendLine("Arizona        10  6  0");
        output.AppendLine("St. Louis      7   9  0");
        output.AppendLine();
        output.AppendLine("NFC North      W   L  T");
        output.AppendLine("-----------------------");
        output.AppendLine("Green Bay      8   7  1");
        output.AppendLine("Chicago        8   8  0");
        output.AppendLine("Detroit        7   9  0");
        output.AppendLine("Minnesota      5  10  1");
        Console.Write(output);
    }
}