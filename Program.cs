internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 200'000]
        int m = tokens[1]; // [1, 1'000'000'000]

        // length = [1, 200'000]
        // element = [0, 1'000'000'000]
        int[] complaints = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        PriorityQueue<int, int> pq = new();

        long sum = 0;
        int eggplants = 0;
        for (int i = 0; i < complaints.Length; ++i) // max tc = 200'000
        {
            int complaint = complaints[i]; // [0, 1'000'000'000]

            sum += complaint;
            pq.Enqueue(complaint, -complaint);

            if (sum >= m)
            {
                sum -= pq.Dequeue() * 2;
                ++eggplants;
            }
        }
        Console.Write(eggplants);
    }
}