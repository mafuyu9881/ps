using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        int inputLength = input.Length;

        int[] numbers = new int[inputLength];
        {
            for (int i = 0; i < inputLength; ++i)
            {
                numbers[i] = input[i] - '0';
            }

            Array.Sort(numbers, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        StringBuilder output = new();
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                output.Append(numbers[i]);
            }
        }

        Console.Write(output);
    }
}