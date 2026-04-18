using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new();
        {
            int t = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < t; ++i)
            {
                int sum = 0;
                {
                    int n = int.Parse(Console.ReadLine()!);
                    int[] numbers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                    for (int j = 0; j < n; ++j)
                    {
                        sum += numbers[j];
                    }
                }
                
                output.AppendLine($"{sum}");
            }
        }

        Console.Write(output);
    }
}