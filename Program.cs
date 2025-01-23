internal class Program
{
    private static int[] _singleDigitMatches = new int[] { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
    private static int[] _doubleDigitMatches = new int[100];

    private static void Main(string[] args)
    {
        for (int i = 0; i < _doubleDigitMatches.Length; ++i) // tc = 100
        {
            _doubleDigitMatches[i] = ComputeDoubleDigitMatches(i);
        }

        int n = int.Parse(Console.ReadLine()!); // n = [1, 50]

        n -= 4; // matches used in plus and equal signs

        string output = "impossible";
        for (int rhs = 0; rhs < 100; ++rhs) // tc = 100
        {
            for (int lhsl = 0; lhsl <= rhs / 2; ++lhsl) // max tc = 50 [0, 49]
            {
                int lhsr = rhs - lhsl; // left-hand side's right

                if (n < _doubleDigitMatches[lhsl] + _doubleDigitMatches[lhsr] + _doubleDigitMatches[rhs])
                    continue;

                output = $"{PrintInDoubleDigit(lhsl)}+{PrintInDoubleDigit(lhsr)}={PrintInDoubleDigit(rhs)}";
                goto Print;
            }
        }
Print:  Console.Write(output);
    }

    private static int ComputeDoubleDigitMatches(int number)
    {
        // number = [0, 99]
        return _singleDigitMatches[number / 10] + _singleDigitMatches[number % 10];
    }

    private static string PrintInDoubleDigit(int number)
    {
        return (number < 10) ? ("0" + number) : $"{number}";
    }
}