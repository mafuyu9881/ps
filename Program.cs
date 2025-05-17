using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 20]

        int length = 0;
        int targetIndex = 0;
        string[] tokens = new string[n];
        for (int i = 0; i < n; ++i)
        {
            string token = Console.ReadLine()!;

            tokens[i] = token;

            if (token == "$")
            {
                targetIndex = i;
            }
            else
            {
                length += token.Length;
            }
        }

        for (int i = length; i < 1000; ++i)
        {
            string word = ConvertNumberToWord(i);

            if (length + word.Length == i)
            {
                tokens[targetIndex] = word;
                break;
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            sb.Append($"{tokens[i]} ");
        }
        Console.Write(sb);
    }

    private static string ConvertNumberToWord(int n)
    {
        string ns = n.ToString();

        StringBuilder sb = new();
        {
            if (ns.Length == 3)
            {
                char c = sb[0];
                if (c == '1')
                {
                    sb.Append("onehundred");
                }
                else if (c == '2')
                {
                    sb.Append("twohundred");
                }
                else if (c == '3')
                {
                    sb.Append("threehundred");
                }
                else if (c == '4')
                {
                    sb.Append("fourhundred");
                }
                else if (c == '5')
                {
                    sb.Append("fivehundred");
                }
                else if (c == '6')
                {
                    sb.Append("sixhundred");
                }
                else if (c == '7')
                {
                    sb.Append("sevenhundred");
                }
                else if (c == '8')
                {
                    sb.Append("eighthundred");
                }
                else
                {
                    sb.Append("ninehundred");
                }
                ns = ns.Substring(1);
            }

            if (ns.Length >= 2)
            {
                int c = ns[0];
                if (ns == "10")
                {
                    sb.Append("ten");
                }
                else if (ns == "11")
                {
                    sb.Append("eleven");
                }
                else if (ns == "12")
                {
                    sb.Append("twelve");
                }
                else if (ns == "13")
                {
                    sb.Append("thirteen");
                }
                else if (ns == "14")
                {
                    sb.Append("fourteen");
                }
                else if (ns == "15")
                {
                    sb.Append("fifteen");
                }
                else if (ns == "16")
                {
                    sb.Append("sixteen");
                }
                else if (ns == "17")
                {
                    sb.Append("seventeen");
                }
                else if (ns == "18")
                {
                    sb.Append("eighteen");
                }
                else if (ns == "19")
                {
                    sb.Append("nineteen");
                }
                else if (c == '2')
                {
                    sb.Append("twenty");
                }
                else if (c == '3')
                {
                    sb.Append("thirty");
                }
                else if (c == '4')
                {
                    sb.Append("forty");
                }
                else if (c == '5')
                {
                    sb.Append("fifty");
                }
                else if (c == '6')
                {
                    sb.Append("sixty");
                }
                else if (c == '7')
                {
                    sb.Append("seventy");
                }
                else if (c == '8')
                {
                    sb.Append("eighty");
                }
                else if (c == '9')
                {
                    sb.Append("ninety");
                }

                if (c == '1')
                {
                    ns = "";
                }
                else
                {
                    ns = ns.Substring(1);
                }
            }

            if (ns.Length >= 1)
            {
                char c = ns[0];
                if (c == '1')
                {
                    sb.Append("one");
                }
                else if (c == '2')
                {
                    sb.Append("two");
                }
                else if (c == '3')
                {
                    sb.Append("three");
                }
                else if (c == '4')
                {
                    sb.Append("four");
                }
                else if (c == '5')
                {
                    sb.Append("five");
                }
                else if (c == '6')
                {
                    sb.Append("six");
                }
                else if (c == '7')
                {
                    sb.Append("seven");
                }
                else if (c == '8')
                {
                    sb.Append("eight");
                }
                else if (c == '9')
                {
                    sb.Append("nine");
                }
            }
        }
        return sb.ToString();
    }
}