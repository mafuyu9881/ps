// n! / r!(n-r)!에서 반복문의 조건식을 활용하여 r!으로 n!을 나누는 효과를 구현하는 방법
internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        int a = 1;
        int b = 1;

        for (int i = 0; i < k; ++i)
        {
            a *= n - i;
            b *= k - i;
        }

        Console.Write(a / b);
    }
}