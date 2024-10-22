using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string pattern = Console.ReadLine()!;

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine()!;

            output.AppendLine(PatternValidation(pattern, s) ? "DA" : "NE");
        }
        Console.Write(output);
    }

    private static bool PatternValidation(string pattern, string s)
    {
        const char InvalidCharacter = '*';

        Queue<char> frontPattern = new();
        for (int i = 0; pattern[i] != InvalidCharacter; ++i)
        {
            frontPattern.Enqueue(pattern[i]);
        }
        
        int frontReadCount = 0;
        while (frontPattern.Count > 0)
        {
            char c = frontPattern.Dequeue();

            if (frontReadCount >= s.Length)
                return false;

            if (s[frontReadCount] != c)
                return false;

            ++frontReadCount;
        }

        Queue<char> backPattern = new();
        for (int i = pattern.Length - 1; pattern[i] != InvalidCharacter; --i)
        {
            backPattern.Enqueue(pattern[i]);
        }

        int backReadCount = 0;
        while (backPattern.Count > 0)
        {
            char c = backPattern.Dequeue();

            int currentReadIndex = s.Length - 1 - backReadCount;

            if (currentReadIndex <= frontReadCount - 1)
                return false;

            if (s[currentReadIndex] != c)
                return false;

            ++backReadCount;
        }

        return true;
    }
}