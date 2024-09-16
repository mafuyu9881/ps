using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return;

        int t = int.Parse(tokens[0]);

        StringBuilder output = new();

        for (int i = 0; i < t; ++i)
        {
            string s = Console.ReadLine()!;

            int sum = 0;
            int streak_count = 1;
            for (int j = 0; j < s.Length; ++j)
            {
                char c = s[j];
                if (c == 'O')
                {
                    sum += streak_count;
                    ++streak_count;
                }
                else
                {
                    streak_count = 1;
                }
            }

            output.AppendLine(sum.ToString());
        }

        Console.Write(output);
    }
}