using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int SushiTypes = 200000;

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int m = tokens[1]; // [1, 200'000]
        
        Queue<int>[] bookers = new Queue<int>[SushiTypes + 1]; // 200'000 * 4B = 800'000B = 0.8MB
        {
            for (int i = 1; i < bookers.Length; ++i) // tc = 200'000
            {
                bookers[i] = new();
            }

            for (int i = 0; i < n; ++i) // max tc = 100'000
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

                int k = tokens[0]; // [?, ?]
                for (int j = 0; j < k; ++j) // max tc = ?
                {
                    int sushiType = tokens[1 + j];
                    bookers[sushiType].Enqueue(i);
                }
            }
        }

        int[] eatingCount = new int[n];
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < tokens.Length; ++i) // max tc = 200'000
            {
                int sushiType = tokens[i];
                if (bookers[sushiType].Count < 1)
                    continue;

                int booker = bookers[sushiType].Dequeue();

                ++eatingCount[booker];
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            sb.Append($"{eatingCount[i]} ");
        }
        Console.Write(sb);
    }
}