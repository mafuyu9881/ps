using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        SortedSet<int> sortedSet = new();
        Dictionary<int, int> countLookup = new();

        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; ++i)
        {
            int k = int.Parse(Console.ReadLine()!);
            for (int j = 0; j < k; ++j)
            {
                string[] tokens = Console.ReadLine()!.Split();
                string command = tokens[0];
                int n = int.Parse(tokens[1]);

                if (command == "I")
                {
                    if (countLookup.ContainsKey(n))
                    {
                        ++countLookup[n];
                    }
                    else
                    {
                        countLookup.Add(n, 1);
                        sortedSet.Add(n);
                    }
                }
                else // if (command == "D")
                {
                    if (sortedSet.Count < 1)
                        continue;

                    int dequeuedElement;
                    if (n == 1)
                    {
                        dequeuedElement = sortedSet.Max();
                    }
                    else
                    {
                        dequeuedElement = sortedSet.Min();
                    }

                    --countLookup[dequeuedElement];
                    if (countLookup[dequeuedElement] < 1)
                    {
                        countLookup.Remove(dequeuedElement);
                        sortedSet.Remove(dequeuedElement);
                    }
                }
            }

            if (sortedSet.Count > 0)
            {
                output.AppendLine($"{sortedSet.Max()} {sortedSet.Min()}");
            }
            else
            {
                output.AppendLine($"EMPTY");
            }
        }
        Console.Write(output);
    }
}