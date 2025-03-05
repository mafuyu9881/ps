internal class Program
{
    private static int[] _weights = null!;
    private static bool[] _measured = null!;

    private static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine()!); // [3, 13]

        // max tc = 200'000
        // element = [1, 200'000]
        _weights = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        // max tc = 13
        // [91, about 13 * 200'000]
        int weightSum = _weights.Sum();

        _measured = new bool[weightSum + 1]; // max sc = about 13 * 200'000 * 4B = 5.4MB

        Measure(0, 0);

        int measurables = 0;
        for (int i = 1; i < _measured.Length; ++i) // max tc = about 13 * 200'000
        {
            if (_measured[i] == false)
            {
                ++measurables;
            }
        }
        Console.Write(measurables);
    }

    private static void Measure(int currIndex, int measuredWeight)
    {
        if (currIndex > _weights.Length - 1)
        {
            if (measuredWeight > 0)
            {
                _measured[measuredWeight] = true;
            }
        }
        else
        {
            int nextIndex = currIndex + 1;

            int weight = _weights[currIndex];

            Measure(nextIndex, measuredWeight);
            Measure(nextIndex, measuredWeight + weight);
            Measure(nextIndex, measuredWeight - weight);
        }
    }
}