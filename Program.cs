using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        int eCount = 0;
        for (int i = 0; i < input.Length; ++i)
        {
            if (input[i] == 'e')
            {
                ++eCount;
            }
        }
        eCount *= 2;

        StringBuilder output = new();
        output.Append('h');
        for (int i = 0; i < eCount; ++i)
        {
            output.Append('e');
        }
        output.Append('y');
        Console.Write(output);
    }
}