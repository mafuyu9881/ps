using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 1'000
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int j = tokens[0]; // [1, 1'000]
            int n = tokens[1]; // [1, 1'000]

            PriorityQueue<int, int> boxes = new();
            for (int k = 0; k < n; ++k) // max tc = 1'000
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int v = tokens[0]; // [1, 10'000]
                int h = tokens[1]; // [1, 10'000]
                int a = v * h;
                boxes.Enqueue(a, -a);
            }
            
            int usage = 0;
            while (j > 0)
            {
                j -= boxes.Dequeue();
                ++usage;
            }
            sb.AppendLine($"{usage}");
        }
        Console.Write(sb);
    }
}