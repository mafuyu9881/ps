class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int output = 0;
        {
            for (int i = 0; i < n; ++i)
            {
                string word = Console.ReadLine()!;

                bool grouped = true;
                {
                    bool[] found = new bool['z' - 'a' + 1];

                    found[word[0] - 'a'] = true;

                    for (int j = 1; j < word.Length; ++j)
                    {
                        char prev = word[j - 1];
                        char curr = word[j];

                        if (prev == curr)
                            continue;

                        int currIndex = curr - 'a';
                        if (found[currIndex])
                        {
                            grouped = false;
                            break;
                        }
                        else
                        {
                            found[curr - 'a'] = true;
                        }
                    }
                }

                if (grouped)
                {
                    ++output;
                }
            }
        }

        Console.Write(output);
    }
}