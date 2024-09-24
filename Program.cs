// 시간 제한: 3초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 100,000
// 100,000 ^ 2 = 10,000,000,000
// 12B * 100,000 = 1,200,000B = 1.2MB
// 4B * (3 + 1 + 100) * 100,000 = 41,600,000B = 41.6MB

// 계수 정렬을 이용한 풀이

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int max_age = 200;
        int accounts_length = max_age + 1;
        List<string>?[] accounts = new List<string>[accounts_length];

        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            int age = int.Parse(tokens[0]);

            if (accounts[age] == null)
                accounts[age] = new();

            accounts[age]!.Add(tokens[1]);
        }

        StringBuilder output = new();
        for (int age = 1; age < accounts_length; ++age)
        {
            List<string>? same_age_accounts = accounts[age];
            if (same_age_accounts == null)
                continue;
            
            for (int i = 0; i < same_age_accounts.Count; ++i)
            {
                output.AppendLine($"{age} {same_age_accounts[i]}");
            }
        }
        Console.Write(output);
    }
}