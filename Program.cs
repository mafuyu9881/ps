using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int scenario = 1;

        StringBuilder output = new();
        while (true)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n == 0)
                break;
            
            string[] names = new string[n];
            for (int i = 0; i < n; ++i)
            {
                names[i] = Console.ReadLine()!;
            }

            int[] count = new int[n];
            for (int i = 0; i < 2 * n - 1; ++i)
            {
                string[] indexState = Console.ReadLine()!.Split();
                int index = int.Parse(indexState[0]) - 1;
                ++count[index];
            }

            for (int i = 0; i < n; ++i)
            {
                if (count[i] % 2 == 1)
                {
                    output.AppendLine($"{scenario} {names[i]}");
                }
            }

            ++scenario;
        }

        Console.Write(output);
    }
}