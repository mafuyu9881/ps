using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 1,000,000
        int sLength = int.Parse(Console.ReadLine()!); // 2n+1 ≤ sLength ≤ 1,000,000
        string s = Console.ReadLine()!;

        int output = 0;
        LinkedList<char> charLL = new();
        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];

            if (c == 'I')
            {
                if (charLL.Count > 0 && charLL.Last!.Value == c)
                {
                    charLL.Clear();
                }

                charLL.AddLast(c);

                if (charLL.Count >= 2 * n + 1)
                {
                    charLL.RemoveFirst();
                    charLL.RemoveFirst();
                    ++output;
                }
            }
            else // if (c == 'O')
            {
                if (charLL.Count < 1)
                    continue;

                if (charLL.Last!.Value == c)
                {
                    charLL.Clear();
                }
                else
                {
                    charLL.AddLast(c);
                }
            }
        }
        Console.Write(output);
    }
}