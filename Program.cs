using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        string s = Console.ReadLine()!;
        Console.Write(s[0] - 0xAC00 + 1);
    }
}