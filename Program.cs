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
            input = Console.ReadLine()!;

            tokens = input.Split();
            if (tokens == null || tokens.Length < 2)
                continue;

            int r = int.Parse(tokens[0]);
            string s = tokens[1];
            int s_length = s.Length;

            int s2_length = r * s_length;
            StringBuilder s2 = new(s2_length);
            s2.Length = s2_length;
            int s2_written_index = 0;

            for (int j = 0; j < s_length; ++j)
            {
                char c = s[j];
                for (int k = 0; k < r; ++k)
                {
                    s2[s2_written_index] = c;
                    ++s2_written_index;
                }
            }

            output.Append(s2);
            output.Append(Environment.NewLine);
        }

        Console.Write(output);
    }
}