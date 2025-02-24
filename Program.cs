using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string s = Console.ReadLine()!; // length = [1, 1'000'000]

        string explosive = Console.ReadLine()!; // length = [1, 36]

        LinkedList<int> indices = new();
        LinkedList<char> actual = new();
        for (int i = 0; i < s.Length; ++i) // max tc = 1'000'000
        {
            int expectedExplosiveCharIndex;
            if (indices.Count > 0)
            {
                expectedExplosiveCharIndex = indices.Last!.Value + 1;
            }
            else
            {
                expectedExplosiveCharIndex = 0;
            }

            char c = s[i];
            
            actual.AddLast(c);

            if (c == explosive[expectedExplosiveCharIndex])
            {
                indices.AddLast(expectedExplosiveCharIndex);

                if (expectedExplosiveCharIndex == explosive.Length - 1)
                {
                    for (int j = 0; j < explosive.Length; ++j) // max tc = 36
                    {
                        indices.RemoveLast();
                        actual.RemoveLast();
                    }
                }
            }
            else if (c == explosive[0])
            {
                indices.AddLast(0);
            }
            else
            {
                indices.AddLast(-1);
            }
        }

        StringBuilder sb = new();
        if (actual.Count > 0)
        {
            for (var lln = actual.First; lln != null; lln = lln.Next)
            {
                sb.Append(lln.Value);
            }
        }
        else
        {
            sb.AppendLine("FRULA");
        }
        Console.Write(sb);
    }
}