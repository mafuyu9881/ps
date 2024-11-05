using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

            long tArea = tokens[0] * tokens[1];
            long eArea = tokens[2] * tokens[3];

            string winner;
            if (tArea > eArea)
            {
                winner = "TelecomParisTech";
            }
            else if (tArea < eArea)
            {
                winner = "Eurecom";
            }
            else
            {
                winner = "Tie";
            }
            output.AppendLine(winner);
        }
        Console.Write(output);
    }
}