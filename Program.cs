using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        {
            for (int i = 0; i < t; ++i)
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int a = tokens[0];
                int b = tokens[1];
                
                int index = 1;
                for (int j = 0; j < b; ++j)
                {
                    index = (index * a) % 10;

                    if (index == 0)
                    {
                        index = 10;
                    }
                }
                output.AppendLine($"{index}");
            }
        }
        Console.Write(output);
    }
}