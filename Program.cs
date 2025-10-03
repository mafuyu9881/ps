using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            string s = Console.ReadLine()!;
            if (s == "END")
                break;

            for (int i = s.Length - 1; i >= 0; --i)
            {
                sb.Append(s[i]);
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}