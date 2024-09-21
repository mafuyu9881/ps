// 이항 계수의 성질(nC0 = nCn = 1, nCk = n-1Ck-1 + n-1Ck)을 이용한 풀이
internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        Console.Write(binomial_coefficient(n, k));
    }

    private static int binomial_coefficient(int n, int k)
    {
        if (k == 0 || n == k)
            return 1;

        return binomial_coefficient(n - 1, k - 1) + binomial_coefficient(n - 1, k);
    }
}