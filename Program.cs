internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        PriorityQueue<int, int> pizzaTowers = new();
        pizzaTowers.Enqueue(n, n);
        int pleasure = 0;
        while (pizzaTowers.Count > 0)
        {
            int height = pizzaTowers.Dequeue();

            int separatedHeight0 = height / 2;
            int separatedHeight1 = height - separatedHeight0;

            pleasure += separatedHeight0 * separatedHeight1;

            if (separatedHeight0 > 1)
                pizzaTowers.Enqueue(separatedHeight0, separatedHeight0);

            if (separatedHeight1 > 1)
                pizzaTowers.Enqueue(separatedHeight1, separatedHeight1);
        }
        Console.Write(pleasure);
    }
}