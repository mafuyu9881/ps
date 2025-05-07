using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] typed = new int[128];
        int typedCharacters = 0;

        StringBuilder sb = new();
        while (true)
        {
            int m = int.Parse(Console.ReadLine()!); // [1, 128]
            if (m == 0)
                break;

            string s = Console.ReadLine()!;

            int maxLength = 0;
            {
                for (int i = 0; i < typed.Length; ++i)
                {
                    typed[i] = 0;
                }
                typedCharacters = 0;

                int lo = 0;
                int hi = 0;
                int length = 0;
                while (hi < s.Length)
                {
                    char newCharacter = s[hi];

                    if (typed[newCharacter] < 1)
                    {
                        ++typedCharacters;
                    }

                    ++typed[newCharacter];

                    while (typedCharacters > m)
                    {
                        char oldCharacter = s[lo];

                        --typed[oldCharacter];

                        if (typed[oldCharacter] < 1)
                        {
                            --typedCharacters;
                        }

                        --length;
                        ++lo;
                    }

                    ++length;
                    ++hi;

                    maxLength = Math.Max(maxLength, length);
                }
            }
            sb.AppendLine($"{maxLength}");
        }
        Console.Write(sb);
    }
}