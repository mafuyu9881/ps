using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        
        string[] tokens = input.Split();
        if (tokens == null)
            return;

        int tokens_length = tokens.Length;
        if (tokens_length < 1)
            return;

        bool ascending = true;
        bool descending = true;
        for (int i = 0; i < tokens_length; ++i)
        {
            int semantics_index = i + 1;

            int c_major_index = int.Parse(tokens[i]);

            if (c_major_index != semantics_index)
                ascending = false;

            if (c_major_index != 9 - semantics_index)
                descending = false;
        }

        if (ascending)
        {
            Console.Write("ascending");
        }
        else if (descending)
        {
            Console.Write("descending");
        }
        else
        {
            Console.Write("mixed");
        }
    }
}