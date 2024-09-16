using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int? a = ReadNumberLine();
        int? b = ReadNumberLine();
        int? c = ReadNumberLine();

        if (a == null || b == null || c == null)
            return;

        string s = (a * b * c).Value.ToString();
        if (s == null)
            return;

        int s_length = s.Length;
        if (s_length < 1)
            return;

        int usage_count_map_length = 10;
        int[] usage_count_map = Enumerable.Repeat(element: 0, count: usage_count_map_length).ToArray();
        
        for (int i = 0; i < s_length; ++i)
        {
            int n = s[i] - '0';
            if (n < usage_count_map_length)
            {
                ++usage_count_map[n];
            }
        }

        StringBuilder output = new StringBuilder();
        
        for (int i = 0; i < usage_count_map_length; ++i)
        {
            output.AppendLine(usage_count_map[i].ToString());
        }

        Console.Write(output);
    }

    private static int? ReadNumberLine()
    {
        string? input = Console.ReadLine();
        if (input == null)
            return null;

        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return null;
        
        return int.Parse(tokens[0]);
    }
}