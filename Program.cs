using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // n에 대한 입력이다. 굳이 필요하진 않으므로 읽고 버린다.
        string? input = Console.ReadLine();
        input = Console.ReadLine();
        
        if (input == null)
            return;

        int input_length = input.Length;
        
        int sum = 0;

        for (int i = 0; i < input_length; ++i)
        {
            sum += input[i] - '0';
        }

        Console.Write(sum);
    }
}

//Console.ReadKey();