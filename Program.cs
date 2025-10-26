class Program
{
    static void Main(string[] args)
    {
        string a = Console.ReadLine()!;
        string b = Console.ReadLine()!;
        string c = Console.ReadLine()!;

        string isbn = "9780921418" + a + b + c;

        int sum = 0;
        for (int i = 0; i < isbn.Length; ++i)
        {
            int digit = isbn[i] - '0';
            if (i % 2 == 0)
            {
                sum += digit * 1;
            }
            else
            {
                sum += digit * 3;
            }
        }
        Console.Write($"The 1-3-sum is {sum}");
    }
}