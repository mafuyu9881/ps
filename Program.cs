using System.Reflection.Metadata.Ecma335;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb = new();
        while (true)
        {
            string token = Console.ReadLine()!;
            if (token == "CU")
            {
                sb.AppendLine("see you");
            }
            else if (token == ":-)")
            {
                sb.AppendLine("I’m happy");
            }
            else if (token == ":-(")
            {
                sb.AppendLine("I’m unhappy");
            }
            else if (token == ";-)")
            {
                sb.AppendLine("wink");
            }
            else if (token == ":-P")
            {
                sb.AppendLine("stick out my tongue");
            }
            else if (token == "(~.~)")
            {
                sb.AppendLine("sleepy");
            }
            else if (token == "TA")
            {
                sb.AppendLine("totally awesome");
            }
            else if (token == "CCC")
            {
                sb.AppendLine("Canadian Computing Competition");
            }
            else if (token == "CUZ")
            {
                sb.AppendLine("because");
            }
            else if (token == "TY")
            {
                sb.AppendLine("thank-you");
            }
            else if (token == "YW")
            {
                sb.AppendLine("you’re welcome");
            }
            else if (token == "TTYL")
            {
                sb.AppendLine("talk to you later");
                break;
            }
            else
            {
                sb.AppendLine(token);
            }
        }
        Console.Write(sb);
    }
}