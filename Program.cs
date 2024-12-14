internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        PriorityQueue<int, int> cardBundles = new();
        for (int i = 0; i < n; ++i)
        {
            int cardBundle = int.Parse(Console.ReadLine()!);

            cardBundles.Enqueue(cardBundle, cardBundle);
        }
        
        int output = 0;
        while (cardBundles.Count > 1)
        {
            int firstCardBundle = cardBundles.Dequeue();
            int secondCardBundle = cardBundles.Dequeue();
            int newCardBundle = firstCardBundle + secondCardBundle;
            cardBundles.Enqueue(newCardBundle, newCardBundle);
            output += newCardBundle;
        }
        Console.Write(output);
    }
}