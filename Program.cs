using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();

        int input_length = 9;

        int max = 0;
        int max_index = -1;
        
        for (int i = 0; i < input_length; ++i)
        {
            string? input = Console.ReadLine();
            if (input == null)
                continue;
            
            int a = int.Parse(input);
            if (a < max)
                continue;

            max = a;
            max_index = i + 1;
        }

        output.AppendLine(max.ToString());
        output.Append(max_index);

        Console.Write(output);
    }
}

//Console.ReadKey();