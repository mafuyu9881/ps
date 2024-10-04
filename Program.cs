using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        Dictionary<int, string> indexNameDictionary = new();
        Dictionary<string, int> nameIndexDictionary = new();
        for (int i = 1; i < n + 1; ++i)
        {
            string name = Console.ReadLine()!;

            indexNameDictionary.Add(i, name);
            nameIndexDictionary.Add(name, i);
        }

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            string input = Console.ReadLine()!;
            
            string append;
            if (input[0] < 'A')
            {
                append = indexNameDictionary[int.Parse(input)];
            }
            else
            {
                append = $"{nameIndexDictionary[input]}";
            }
            output.AppendLine(append);
        }
        Console.Write(output);
    }
}