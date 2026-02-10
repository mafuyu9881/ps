using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] count = new int['z' - 'a' + 1];

        for (int i = 0; i < n; ++i)
        {
            string name = Console.ReadLine()!;

            char firstChar = name[0];

            int firstCharHash = LowerCaseToIndex(firstChar);

            ++count[firstCharHash];
        }

        StringBuilder output = new();
        for (int i = 0; i < count.Length; ++i)
        {
            if (count[i] < 5)
                continue;

            output.Append(IndexToLowerCase(i));
        }

        if (output.Length < 1)
        {
            output.Append("PREDAJA");
        }

        Console.Write(output);
    }

    static int LowerCaseToIndex(char c)
    {
        return c - 'a';
    }
    static char IndexToLowerCase(int index)
    {
        return (char)('a' + index);
    }
}