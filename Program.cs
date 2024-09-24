// 시간 제한: 3초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 100,000
// 100,000 ^ 2 = 10,000,000,000
// 12B * 100,000 = 1,200,000B = 1.2MB
// 4B * (3 + 1 + 100) * 100,000 = 41,600,000B = 41.6MB

using System.Text;

// age, order, name
using Account = System.Tuple<int, int, string>;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Account[] accounts = new Account[n];

        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            accounts[i] = new Account(int.Parse(tokens[0]), i, tokens[1]);
        }

        merge_sort(accounts);
        
        StringBuilder output = new();
        for (int i = 0; i < accounts.Length; ++i)
        {
            output.AppendLine($"{accounts[i].Item1} {accounts[i].Item3}");
        }
        Console.Write(output);
    }

    private static void merge_sort(Span<Account> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;

        int mid = arr_length / 2;
        
        merge_sort(arr.Slice(0, mid));
        merge_sort(arr.Slice(mid));
        merge(arr, mid);
    }

    private static void merge(Span<Account> arr, int mid)
    {
        Account[] backedup = arr.ToArray();

        int arr_length = arr.Length;

        int left_read_index = 0;
        int right_read_index = mid;
        int written_index = 0;

        while (left_read_index < mid && right_read_index < arr_length)
        {
            Account left_read_account = backedup[left_read_index];
            Account right_read_account = backedup[right_read_index];

            if (left_read_account.Item1 < right_read_account.Item1 ||
               (left_read_account.Item1 == right_read_account.Item1 &&
                left_read_account.Item2 < right_read_account.Item2))
            {
                arr[written_index] = backedup[left_read_index];
                ++left_read_index;
            }
            else
            {
                arr[written_index] = backedup[right_read_index];
                ++right_read_index;
            }
            ++written_index;
        }

        while (left_read_index < mid)
        {
            arr[written_index] = backedup[left_read_index];
            ++left_read_index;
            ++written_index;
        }

        while (right_read_index < arr_length)
        {
            arr[written_index] = backedup[right_read_index];
            ++right_read_index;
            ++written_index;
        }
    }
}