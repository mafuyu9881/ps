using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            int c = tokens[2];

            int tuples = 0;
            for (int j = 1; j <= a; ++j)
            {
                for (int k = 1; k <= b; ++k)
                {
                    for (int l = 1; l <= c; ++l)
                    {
                        if ((j % k == k % l) && (k % l == l % j))
                        {
                            ++tuples;
                        }
                    }
                }
            }
            output.AppendLine($"{tuples}");
        }
        Console.Write(output);
    }
}