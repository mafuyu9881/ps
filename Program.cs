using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();

        for (int stars = n; stars > 0; --stars)
        {
            for (int i = n; i > 0; --i)
            {
                output.Append((i <= stars) ? '*' : ' ');
            }
            output.AppendLine();
        }
        
        Console.Write(output);
    }
}