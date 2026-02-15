class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] names = new string[n];
        for (int i = 0; i < n; ++i)
        {
            names[i] = Console.ReadLine()!;
        }

        int nameLength = names[0].Length;

        char[] output = new char[nameLength];
        {
            for (int i = 0; i < nameLength; ++i)
            {
                char c = names[0][i];
                for (int j = 1; j < n; ++j)
                {
                    if (c != names[j][i])
                    {
                        c = '?';
                        break;
                    }
                }
                output[i] = c;
            }
        }

        Console.Write(output);
    }
}