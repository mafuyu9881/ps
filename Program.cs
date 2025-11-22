using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine()!);
        StringBuilder output = new();
        for (int i = 0; i < l; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            int n = int.Parse(tokens[0]);
            string x = tokens[1];
            for (int j = 0; j < n; ++j)
            {
                output.Append(x);
            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}