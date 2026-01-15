using System.Data;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int a = tokens[0];
            if (a == 0)
                break;

            int growingPoints = 1;
            for (int i = 0; i < a; ++i)
            {
                int splittingFactor = tokens[i * 2 + 1];
                int cut = tokens[i * 2 + 2];

                growingPoints = growingPoints * splittingFactor - cut;
            }

            output.AppendLine($"{growingPoints}");
        }
        Console.Write(output);
    }
}