internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [3, 200]
        int m = tokens[1]; // [1, n] = [1, 200]
        int k = tokens[2]; // [0, 1'000'000]

        bool[] frontBuffer = new bool[n];
        bool[] backBuffer = new bool[n];

        for (int i = 0; i < m; ++i) // max tc = 200
        {
            frontBuffer[int.Parse(Console.ReadLine()!)] = true;
        }

        Action SwapBuffer = () =>
        {
            var temp = frontBuffer;
            frontBuffer = backBuffer;
            backBuffer = temp;
        };
        
        for (int i = 0; i < k; ++i) // max tc = 1'000'000
        {
            for (int index = 0; index < n; ++index) // max tc = 200
            {
                int prevIndex = (index - 1 + n) % n;
                int nextIndex = (index + 1) % n;
                backBuffer[index] = frontBuffer[prevIndex] != frontBuffer[nextIndex];
            }
            SwapBuffer();
        }

        int greetings = 0;
        for (int i = 0; i < frontBuffer.Length; ++i) // max tc = 1'000'000
        {
            if (frontBuffer[i])
            {
                ++greetings;
            }
        }
        Console.Write(greetings);
    }
}