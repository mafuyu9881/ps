using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        int[] sets = new int[n + 1];
        for (int i = 0; i < sets.Length; ++i)
        {
            sets[i] = i;
        }

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int command = tokens[0];
            int a = tokens[1];
            int b = tokens[2];

            if (command == 0)
            {
                int aID = sets[a];
                int bID = sets[b];

                int unionID = Math.Min(aID, bID);

                sets[a] = unionID;
                sets[b] = unionID;
            }
            else // (command == 1)
            {
                output.AppendLine((sets[a] == sets[b]) ? "YES" : "NO");
            }
        }
        Console.Write(output);
    }
}