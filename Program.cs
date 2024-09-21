internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        int n = int.Parse(tokens[0]);
        int k = int.Parse(tokens[1]);

        int?[] backedup_factorials = new int?[((n > k) ? n : k) + 1];

        Console.Write(factorial(n, backedup_factorials) / factorial(k, backedup_factorials) / factorial(n - k, backedup_factorials));
    }

    // backedup_factorials는 null이 아니고, n을 키 값으로 항상 사용할 수 있는 상태라고 전제합니다.
    private static int factorial(int n, int?[] backedup_factorials)
    {
        if (n == 0)
        {
            backedup_factorials[0] = 1;
        }
        else
        {
            if (backedup_factorials[n] == null)
            {
                backedup_factorials[n] = n * factorial(n - 1, backedup_factorials);
            }
        }

        return backedup_factorials[n]!.Value;
    }

    private static int factorial(int n)
    {
        if (n == 0)
            return 1;

        return n * factorial(n - 1);
    }
}