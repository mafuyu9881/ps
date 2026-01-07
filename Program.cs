using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        StringBuilder output = new();
        if (s.Length > 2 && s[0] == '"' && s[s.Length - 1] == '"')
        {
            for (int i = 1; i < s.Length - 1; ++i)
            {
                output.Append(s[i]);
            }
        }
        else
        {
            output.Append("CE");
        }
        Console.Write(output);
    }
}