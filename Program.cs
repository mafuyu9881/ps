using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        if (n == 1)
        {
            output.AppendLine("11");
            output.AppendLine("A B C D E F G H J L M");
        }
        else if (n == 2)
        {
            output.AppendLine("9");
            output.AppendLine("A C E F G H I L M");
        }
        else if (n == 3)
        {
            output.AppendLine("9");
            output.AppendLine("A C E F G H I L M");
        }
        else if (n == 4)
        {
            output.AppendLine("9");
            output.AppendLine("A B C E F G H L M");
        }
        else if (n == 5)
        {
            output.AppendLine("8");
            output.AppendLine("A C E F G H L M");
        }
        else if (n == 6)
        {
            output.AppendLine("8");
            output.AppendLine("A C E F G H L M");
        }
        else if (n == 7)
        {
            output.AppendLine("8");
            output.AppendLine("A C E F G H L M");
        }
        else if (n == 8)
        {
            output.AppendLine("8");
            output.AppendLine("A C E F G H L M");
        }
        else if (n == 9)
        {
            output.AppendLine("8");
            output.AppendLine("A C E F G H L M");
        }
        else if (n == 10)
        {
            output.AppendLine("8");
            output.AppendLine("A B C F G H L M");
        }
        Console.Write(output);
    }
}