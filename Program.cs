using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string input = Console.ReadLine()!;

            int steps = 0;
            for (int j = 0; j < input.Length; ++j)
            {
                if (input[j] == 'D')
                    break;
                
                ++steps;
            }
            output.AppendLine($"{steps}");
        }
        Console.Write(output);
    }
}