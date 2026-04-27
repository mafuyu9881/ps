public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += tokens[i];
        }
        sum += (n - 1) * 8;

        Console.Write($"{sum / 24} {sum % 24}");
    }
}