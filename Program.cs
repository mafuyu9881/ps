using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new();
        {
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < (n / 5); ++i)
            {
                output.Append("V");
            }

            for (int i = 0; i < (n % 5); ++i)
            {
                output.Append("I");
            }
        }
        Console.Write(output);
    }
}