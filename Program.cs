internal class Program
{
    private const int Sensors = 360;
    private static bool[] _sensors = new bool[Sensors];
    private static int _sensed = 0;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

        for (int i = 0; i < n; ++i) // max tc = 1'000'000
        {
            // length = 2
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int a = tokens[0];
            int b = tokens[1];

            int target = Adjust(a + 180);

            for (int j = 0; j <= b; ++j) // max tc = 180
            {
                Sense(Adjust(target - j));
                Sense(Adjust(target + j));

                if (_sensed >= Sensors)
                {
                    goto Print;
                }
            }
        }

Print:
        Console.Write(_sensed);
    }

    private static int Adjust(int degree)
    {
        while (degree < 0)
        {
            degree += 360;
        }
        
        while (degree >= 360)
        {
            degree -= 360;
        }

        return degree;
    }

    private static void Sense(int index)
    {
        if (_sensors[index])
            return;

        _sensors[index] = true;
        ++_sensed;
    }
}