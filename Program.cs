using System.Text;

class Program
{
    static void Main(string[] args)
    {
        char[] lookup = new char[] { 'D', 'C', 'B', 'A', 'E' };

        StringBuilder output = new();

        for (int i = 0; i < 3; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int count = 0;
            count += tokens[0];
            count += tokens[1];
            count += tokens[2];
            count += tokens[3];

            output.AppendLine($"{lookup[count]}");
        }

        Console.Write(output);
    }
}