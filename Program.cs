internal class Program
{
    const int Composite = -1;
    const int DequeuingOrder = 3; // 1-based

    private static int[] _table = null!;

    private static void Main(string[] args)
    {
        _table = new int[5000000 + 1];
        _table[0] = Composite;
        _table[1] = Composite;
        for (int i = 1; i < _table.Length; ++i) // tc = 14489913
        {
            if (_table[i] < 0)
                continue;

            for (int j = 2; i * j < _table.Length; ++j)
            {
                _table[i * j] = Composite;
            }
        }

        int n = int.Parse(Console.ReadLine()!); // [5, 100'000]

        long aScore = 0;
        long bScore = 0;
        
        PriorityQueue<int, int> aPrimes = new();
        PriorityQueue<int, int> bPrimes = new();

        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            // element = [0, 5'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int aPresented = tokens[0];
            int bPresented = tokens[1];

            Evaluate(ref aScore, ref bScore, aPrimes, bPrimes, aPresented);
            Evaluate(ref bScore, ref aScore, bPrimes, aPrimes, bPresented);
        }

        if (aScore > bScore)
        {
            Console.Write("소수의 신 갓대웅");
        }
        else if (aScore < bScore)
        {
            Console.Write("소수 마스터 갓규성");
        }
        else
        {
            Console.Write("우열을 가릴 수 없음");
        }
    }

    private static void Evaluate(ref long selfScore,
                                 ref long oppoScore,
                                 PriorityQueue<int, int> selfPrimes,
                                 PriorityQueue<int, int> oppoPrimes,
                                 int presented)
    {
        if (_table[presented] == Composite)
        {
            if (oppoPrimes.Count < DequeuingOrder)
            {
                oppoScore += 1000;
            }
            else
            {
                oppoScore += selfPrimes.Peek(); // max tc = log2(3) = 1.xxx
            }
        }
        else if (_table[presented] > 0)
        {
            selfScore -= 1000;
        }
        else
        {
            _table[presented] = 1;

            selfPrimes.Enqueue(presented, presented); // max tc = log2(3) = 1.xxx

            if (selfPrimes.Count > DequeuingOrder)
            {
                selfPrimes.Dequeue(); // tc = log2(4) = 2
            }
        }
    }
}