using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        
        while (true)
        {
            string n = Console.ReadLine()!;
            int n_length = n.Length;
            
            // n이 빈 문자열일 수는 없음을 전제합니다.
            if (n_length < 2)
            {
                if (n[0] == '0')
                {
                    break;
                }
            }

            bool palindrome = true;
            for (int i = 0; i < n_length / 2; ++i)
            {
                if (n[i] != n[n_length - 1 - i])
                {
                    palindrome = false;
                    break;
                }
            }

            output.AppendLine(palindrome ? "yes" : "no");
        }

        Console.Write(output);
    }
}