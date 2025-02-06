using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int candies = tokens[0]; // [1, 1'000]

            PriorityQueue<int, int> boxes = new();
            for (int j = 0; j < tokens[1]; ++j) // max tc = 1'000
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int v = tokens[0]; // [1, 10'000]
                int h = tokens[1]; // [1, 10'000]
                int a = v * h;
                boxes.Enqueue(a, -a);
            }
            
            int usage = 0;
            while (candies > 0)
            {
                candies -= boxes.Dequeue();
                ++usage;
            }
            sb.AppendLine($"{usage}");
        }
        Console.Write(sb);
    }
}