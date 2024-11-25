internal class Program
{
    private static void Main(string[] args)
    {
        const int Infinity = -1;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        
        int[] distances = new int[b + 1];
        for (int i = 0; i < distances.Length; ++i)
        {
            distances[i] = (i != a) ? Infinity : 0;
        }
        Queue<long> queue = new();
        queue.Enqueue(a);
        while (queue.Count > 0)
        {
            long num = queue.Dequeue();
            int newDistance = distances[num] + 1;
            long[] nextNums = new long[] { num * 2, num * 10 + 1 };
            for (int i = 0; i < nextNums.Length; ++i)
            {
                long nextNum = nextNums[i];
                if (nextNum > b)
                    continue;
                
                int oldDistance = distances[nextNum];
                if (oldDistance != Infinity && oldDistance < newDistance)
                    continue;

                distances[nextNum] = newDistance;
                queue.Enqueue(nextNum);
            }
        }
        int distance = distances[b];
        if (distance != -1)
        {
            ++distance;
        }
        Console.Write(distance);
    }
}