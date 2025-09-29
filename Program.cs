using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        int[] counts = new int['z' - 'a' + 1];

        for (int i = 0; i < s.Length; ++i)
        {
            ++counts[s[i] - 'a'];
        }

        StringBuilder sb = new();
        for (int i = 0; i < counts.Length; ++i)
        {
            sb.Append($"{counts[i]} ");
        }
        Console.Write(sb);
    }
}