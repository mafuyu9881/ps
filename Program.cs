using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string word = Console.ReadLine()!;

            int vowels = 0;
            for (int j = 0; j < word.Length; ++j)
            {
                char c = word[j];
                if (c == 'a' ||
                    c == 'e' ||
                    c == 'i' ||
                    c == 'o' ||
                    c == 'u')
                {
                    ++vowels;
                }
            }
            
            output.AppendLine($"The number of vowels in {word} is {vowels}.");
        }
        
        Console.Write(output);
    }
}