internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]

        string[] strings = new string[n];
        for (int i = 0; i < n; ++i)
        {
            strings[i] = Console.ReadLine()!;
        }

        bool[,] duplicated = new bool[n, n]; // max sc = 10'000

        int output = 0;
        for (int i = 0; i < n; ++i) // max tc = 100
        {
            for (int j = 0; j < n; ++j) // max tc = 100
            {
                if (i == j)
                    continue;

                if (duplicated[i, j])
                    continue;

                string s0 = strings[i];
                string s1 = strings[j];
                for (int k = 0; k < Math.Min(s0.Length, s1.Length); ++k) // max tc = 20
                {
                    // compare the rear of s0 and the head of s1
                    bool localDuplicated = true;
                    for (int l = 0; l <= k; ++l) // max tc = 20
                    {
                        if (s0[s0.Length - 1 - k + l] == s1[l])
                            continue;

                        localDuplicated = false;
                        break;
                    }

                    if (localDuplicated == false)
                        continue;

                    duplicated[i, j] = true;
                    duplicated[j, i] = true;
                    ++output;
                    break;
                }
            }
        }
        Console.Write(output);
    }
}