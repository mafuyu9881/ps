using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i) // max tc = 100
        {
            int n = int.Parse(Console.ReadLine()!); // 0 ≤ n ≤ 30

            Dictionary<string, int> dictionary = new();
            for (int j = 0; j < n; ++j) // max tc = 30
            {
                string[] tokens = Console.ReadLine()!.Split();
                string clothes = tokens[0];
                string kind = tokens[1];

                if (dictionary.ContainsKey(kind))
                {
                    ++dictionary[kind];
                }
                else
                {
                    dictionary.Add(kind, 1 + 1); // '+1' is to consider the case that choose nothing
                }
            }

            int cases = 1;
            foreach (var element in dictionary)
            {
                cases *= element.Value;
            }
            --cases;

            output.AppendLine($"{cases}");
        }
        Console.Write(output);
    }
}