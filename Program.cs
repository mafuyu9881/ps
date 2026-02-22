using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        StringBuilder output = new();
        {
            for (int i = 0; i < n; ++i)
            {
                string[] words = Console.ReadLine()!.Split();

                int wordsLength = words.Length;

                output.Append($"Case #{i + 1}: ");
                for (int j = 0; j < wordsLength; ++j)
                {
                    output.Append($"{words[wordsLength - 1 - j]} ");
                }
                output.AppendLine();
            }
        }

        Console.Write(output);
    }
}