using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]

        // length = [1, 100]
        // element = [1, 300]
        int[] levels = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        StringBuilder sb = new();
        for (int i = 0; i < levels.Length; ++i)
        {
            int level = levels[i];

            int segment = 0;
            if (level >= 0 && level < 250)
            {
                segment = 4;
            }
            else if (level < 275)
            {
                segment = 3;
            }
            else if (level < 300)
            {
                segment = 2;
            }
            else
            {
                segment = 1;
            }
            sb.Append($"{segment} ");
        }
        Console.Write(sb);
    }
}