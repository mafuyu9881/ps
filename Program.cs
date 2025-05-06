using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            string s = Console.ReadLine()!;

            // 0: palindrome
            // 1: pseudo palindrome
            // 2: nothing
            int type = 0;
            {
                int lo = 0;
                int hi = s.Length - 1;
                while (lo < hi)
                {
                    char loC = s[lo];
                    char hiC = s[hi];

                    if (loC == hiC)
                    {
                        ++lo;
                        --hi;
                    }
                    else
                    {
                        if (type == 0)
                        {
                            type = 1;
                        }
                        else
                        {
                            type = 2;
                            break;
                        }

                        if (s[lo + 1] == s[hi])
                        {
                            ++lo;
                        }
                        else if (s[lo] == s[hi - 1])
                        {
                            --hi;
                        }
                        else
                        {
                            type = 2;
                            break;
                        }
                    }
                }
            }
            sb.AppendLine($"{type}");
        }
        Console.Write(sb);
    }
}