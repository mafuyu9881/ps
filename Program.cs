using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int Count = 7;
        const int InvalidMax = 101;

        int sum = 0;
        int min = InvalidMax;
        for (int i = 0; i < Count; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n % 2 == 0)
                continue;

            sum += n;
            min = Math.Min(min, n);
        }
        
        StringBuilder output = new();
        if (min == InvalidMax)
        {
            output.AppendLine("-1");
        }
        else
        {
            output.AppendLine($"{sum}");
            output.AppendLine($"{min}");
        }
        Console.Write(output);
    }
}