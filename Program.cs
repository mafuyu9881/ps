using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // length = 2
        // element = [1, 200'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int q = tokens[1];

        // length = [1, 200'000]
        // element = [1, 1'000'000'000]
        int[] tastes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] sizes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        (int taste, int size)[] apples = new (int, int)[n];
        for (int i = 0; i < apples.Length; ++i) // max tc = 200'000
        {
            apples[i] = (tastes[i], sizes[i]);
        }
        Array.Sort(apples, (x, y) => y.taste.CompareTo(x.taste)); // max tc = 200'000 * log2(200'000) = 200'000 * 17.xxx

        const int Invalid = -1;
        int computingMaxSize = Invalid;
        int computingCount = Invalid;

        LinkedList<(int taste, int count)> answerLL = new();
        (int taste, int count)[] answerArr = null!;
        for (int i = 0; i < apples.Length; ++i) // max tc = 200'000
        {
            var apple = apples[i];

            int computingTaste = apple.taste;
            if (i == 0)
            {
                computingMaxSize = apple.size;
                computingCount = 1;
            }
            else
            {
                if (computingMaxSize == apple.size)
                {
                    ++computingCount;
                }
                else if (computingMaxSize < apple.size)
                {
                    computingMaxSize = apple.size;
                    computingCount = 1;
                }
            }

            int j = i + 1;
            while (j < apples.Length && apple.taste == apples[j].taste) // it doesn't take additional tc
            {
                int sameTasteAppleSize = apples[j].size;
                
                if (computingMaxSize == sameTasteAppleSize)
                {
                    ++computingCount;
                }
                else if (computingMaxSize < sameTasteAppleSize)
                {
                    computingMaxSize = sameTasteAppleSize;
                    computingCount = 1;
                }
                
                ++j;
            }
            i = j - 1;

            answerLL.AddLast((computingTaste, computingCount));
        }
        answerArr = answerLL.ToArray(); // max tc = 200'000

        StringBuilder sb = new();
        for (int i = 0; i < q; ++i) // max tc = 200'000
        {
            int p = int.Parse(Console.ReadLine()!);

            int lo = 0 - 1;
            int hi = (answerArr.Length - 1) + 1;
            while (lo < hi - 1) // max tc = 17.xxx
            {
                int mid = (lo + hi) / 2;

                if (answerArr[mid].taste >= p)
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }

            int answer;
            if (lo < 0 || lo > answerArr.Length - 1)
            {
                answer = 0;
            }
            else
            {
                answer = answerArr[lo].count;
            }
            sb.AppendLine($"{answer}");
        }
        Console.Write(sb);
    }
}