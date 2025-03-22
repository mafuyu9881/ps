using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int Students = 30;
        
        bool[] submitted = new bool[Students];

        for (int i = 0; i < submitted.Length - 2; ++i)
        {
            submitted[int.Parse(Console.ReadLine()!) - 1] = true;
        }

        StringBuilder sb = new();
        for (int i = 0; i < submitted.Length; ++i)
        {
            if (submitted[i])
                continue;

            sb.AppendLine($"{i + 1}");
        }
        Console.Write(sb);
    }
}