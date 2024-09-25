// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ 숫자 카드의 개수 ≤ 500,000
// -10,000,000 ≤ 수의 크기 ≤ 10,000,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int abs_number_limit = 10000000;

        int[] lookup = new int[abs_number_limit * 2 + 1];

        int n = int.Parse(Console.ReadLine()!);
        string[] tokens = Console.ReadLine()!.Split();
        for (int i = 0; i < n; ++i)
        {
            ++lookup[int.Parse(tokens[i]) + abs_number_limit];
        }

        int m = int.Parse(Console.ReadLine()!);
        tokens = Console.ReadLine()!.Split();
        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            output.Append($"{lookup[int.Parse(tokens[i]) + abs_number_limit]} ");
        }
        Console.Write(output);
    }
}