using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();

        for (int i = 0; i < n; ++i)
        {
            string redundant = Console.ReadLine()!;

            StringBuilder deduped = new();
            for (int j = 0; j < redundant.Length; ++j)
            {
                char newChar = redundant[j];
                if (deduped.Length < 1 || deduped[deduped.Length - 1] != newChar)
                {
                    deduped.Append(newChar);
                }
            }
            output.AppendLine(deduped.ToString());
        }
        
        Console.Write(output);
    }
}