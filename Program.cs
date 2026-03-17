using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> fbiIndices = new(5);
        {
            for (int i = 0; i < 5; ++i)
            {
                string input = Console.ReadLine()!;

                if (input.Contains("FBI") == false)
                    continue;

                fbiIndices.Add(i + 1);
            }
        }

        StringBuilder output;
        {
            if (fbiIndices.Count > 0)
            {
                output = new();
                for (int i = 0; i < fbiIndices.Count; ++i)
                {
                    output.Append($"{fbiIndices[i]} ");
                }
            }
            else
            {
                output = new("HE GOT AWAY!");
            }
        }

        Console.Write(output);
    }
}