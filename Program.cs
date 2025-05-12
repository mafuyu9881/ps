using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string s1 = Console.ReadLine()!;
        string s2 = Console.ReadLine()!;

        int[,] map = new int[s1.Length + 1, s2.Length + 1];
        for (int i = 1; i <= s1.Length; ++i)
        {
            for (int j = 1; j <= s2.Length; ++j)
            {
                char c1 = s1[i - 1];
                char c2 = s2[j - 1];
                if (c1 == c2)
                {
                    map[i, j] = map[i - 1, j - 1] + 1;
                }
                else
                {
                    map[i, j] = Math.Max(map[i - 1, j], map[i, j - 1]);
                }
            }
        }
        
        StringBuilder sb = new();
        {
            LinkedList<char> ll = new();
            {
                int i = s1.Length;
                int j = s2.Length;
                while (i > 0 && j > 0)
                {
                    int curr = map[i, j];
                    int t = map[i - 1, j];
                    int l = map[i, j - 1];

                    if (curr > t && curr > l)
                    {
                        ll.AddFirst(s1[i - 1]);
                        --i;
                        --j;
                    }
                    else
                    {
                        if (t > l)
                        {
                            --i;
                        }
                        else
                        {
                            --j;
                        }
                    }
                }
            }

            for (var lln = ll.First; lln != null; lln = lln.Next)
            {
                sb.Append($"{lln.Value}");
            }
        }
        Console.Write(sb);
    }
}