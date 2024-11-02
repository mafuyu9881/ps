using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int k = int.Parse(Console.ReadLine()!);

            int[] files = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            PriorityQueue<long, long> priorityFiles = new();
            for (int j = 0; j < files.Length; ++j)
            {
                int file = files[j];
                priorityFiles.Enqueue(file, file);
            }
            
            long totalCost = 0;
            while (priorityFiles.Count > 1)
            {
                long fileA = priorityFiles.Dequeue();
                long fileB = priorityFiles.Dequeue();

                long cost = fileA + fileB;

                totalCost += cost;

                priorityFiles.Enqueue(cost, cost);
            }
            output.AppendLine($"{totalCost}");
        }
        Console.WriteLine(output);
    }
}