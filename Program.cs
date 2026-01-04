using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);

            StringBuilder votes = new();
            while (n > 0)
            {
                if (n >= 5)
                {
                    votes.Append("++++ ");
                    n -= 5;
                }
                else
                {
                    votes.Append("|");
                    n -= 1;
                }
            }
            output.AppendLine(votes.ToString());
        }
        Console.Write(output);
    }
}