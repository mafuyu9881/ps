using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        
        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return;
        
        int output_length = int.Parse(tokens[0]);
        StringBuilder output = new(output_length);
        output.Length = output_length;
        
        for (int i = 0; i < output_length; ++i)
            output[i] = 'a';
        
        Console.Write(output);
    }
}