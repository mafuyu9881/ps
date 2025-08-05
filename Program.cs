using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        var reverseComparer = Comparer<string>.Create((a, b) => string.Compare(b, a));
        SortedSet<string> employees = new(reverseComparer);
        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            string name = tokens[0];
            string behaviour = tokens[1];

            if (behaviour == "enter")
            {
                employees.Add(name);
            }
            else
            {
                employees.Remove(name);
            }
        }

        StringBuilder sb = new();
        foreach (string name in employees)
        {
            sb.AppendLine(name);
        }
        Console.Write(sb);
    }
}