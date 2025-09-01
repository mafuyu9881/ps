using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();
        while (true)
        {
            string s = Console.ReadLine()!;
            if (s == "#")
                break;

            int count = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];
                if (c == 'a' ||
                    c == 'e' ||
                    c == 'i' ||
                    c == 'o' ||
                    c == 'u' ||
                    c == 'A' ||
                    c == 'E' ||
                    c == 'I' ||
                    c == 'O' ||
                    c == 'U')
                {
                    ++count;
                }
            }
            output.AppendLine($"{count}");
        }
        Console.Write(output);
    }
}