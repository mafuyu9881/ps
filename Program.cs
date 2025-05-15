internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000]
        int m = tokens[1]; // [1, n] = [1, 1'000]

        // length = n = [1, 1'000]
        // element = [1, 1'000]
        int[] waitings = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        // length = m = [1, 1'000]
        // element = [1, 1'000]
        int[] friends = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        //bool[] friend = new bool[1000 + 1];
        //for (int i = 0; i < m; ++i) // max tc = 1'000
        //{
        //    friend[friends[i]] = true;
        //}

        int exchanges = 0;
        {
            int remains = m;
            for (int i = 0; i < n && remains > 0; ++i) // max tc = 1'000
            {
                int waiting = waitings[i];

                bool friend = false;
                for (int j = 0; j < m; ++j) // max tc = 1'000
                {
                    friend |= (waiting == friends[j]);
                }

                if (friend == false)
                {
                    ++exchanges;
                }

                --remains;
            }
        }
        Console.Write(exchanges);
    }
}