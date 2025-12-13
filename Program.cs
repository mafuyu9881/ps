using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string s = Console.ReadLine()!;

        StringBuilder output = new();
        for (int i = n - 5; i < n; ++i)
        {
            output.Append(s[i]);
        }
        Console.Write(output);
    }
}