internal class Program
{
    private static int MAX = 1001;
    private static bool[] _s = new bool[MAX + 1];

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000]
        int m = tokens[1]; // [0, 50]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // element = [1, 1'000]
        for (int i = 0; i < tokens.Length; ++i) // max tc = 50
        {
            _s[tokens[i]] = true;
        }

        const int InvalidDiff = -1;
        int diff = InvalidDiff;
        for (int x = 1; x <= MAX; ++x)
        {
            if (_s[x])
                continue;

            for (int y = 1; y <= MAX; ++y)
            {
                if (_s[y])
                    continue;

                for (int z = 1; z <= MAX; ++z)
                {
                    if (_s[z])
                        continue;

                    int newDiff = Math.Abs(n - x * y * z);
                    if (diff != InvalidDiff && diff <= newDiff)
                        continue;

                    diff = newDiff;
                }
            }
        }
        Console.Write(diff);
    }
}